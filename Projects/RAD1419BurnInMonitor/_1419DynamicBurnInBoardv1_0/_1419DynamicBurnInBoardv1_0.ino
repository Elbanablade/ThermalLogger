#define VERSION "1.2"
#define BOARD_ID "RAD1419 Dynamic BI"
/*
  1419 Dynamic Burn In Firmware
  Includes diagnostic mode as well as sequential running mode
  
  Designed for the Seeeduino Atmega1280 or 2560
  VCC switch at 5V
  RST switch at Auto
  
  January 25, 2012
  
  Original code (v1.0) by JLitzenberger circa 2012.
  v1.1	First fixes by KHartojo 2013-02-05.
		Mainly not reselecting bd and DUT betw Pos and Neg Mon reads,
		and read Bit4 and Active while a DUT is selected.
		The "noise" that was being read by the ADC channels is fixed by installing
		100kOhms//0.1uF on each of ADC channels 0 to 3.
  v1.2  More clean up.
		Remove the RUN mode, GUI only calls 1 brd at a time.
		Move board select/deselect to outside the DUT selection.
  
  NOTE: on the dynamic burn-in boards the "BIT4 OK" and "ADC-RUN" silkscreens are
  swapped. The analog read channels #defines here are correct, but they do NOT
  coinside with the silkscreens on the boards.
  The PMON and NMON silkscreens are correct.
*/

int mode;

int numboards;

#define Bit4            1
#define Active          0
#define Pmon            3
#define Nmon            2

#define MODE_IDLE       0
#define MODE_SETUP      1
#define MODE_DIAGNOSTIC 3
////////////////////////////////////////////////////////////////
void setup()
{
  Serial.begin(115200);
  DDRC = 0xFF;
  DDRL = 0xFF;
  DDRA = 0xF0;
  DDRE = 0xF4;
  PORTE = 0x0B;
  
  PORTC |= 0xFC;
  PORTL |= 0xFF;
  PORTA |= 0xF0;
}
/////////////////////////////////////////////////////////////////
int readSerialChar()
{
 //is there anything available
 if(!Serial.available())
 {
  return -1;; 
 }
 int c = Serial.read();
 return c;
}
/////////////////////////////////////////////////////////////////
char * proc()
{
  //try to get something from the serial port
  int c = readSerialChar();
  //if nothing was received
  if(c < 0)
  {
   if((mode == MODE_IDLE) || (mode == MODE_SETUP) || (mode == MODE_DIAGNOSTIC))
   {
    return 0;
   } 
   return "timeout";
  }
  switch(mode)
  {
   case MODE_IDLE:
   { 
      mode = MODE_IDLE;
      switch(c)
      {
	   case '*':
	   {
	    Serial.print(BOARD_ID);
		Serial.print(" Rev. ");
		Serial.println(VERSION);
		return 0;
	   }
       case '+':
       {
        mode = MODE_SETUP; 
        return 0;
       } 
       case '-':
       {
        mode = MODE_DIAGNOSTIC;
        return 0;
       }
       default:
       {
        return "unknown command"; 
       } break;
      }
   }
   case MODE_SETUP:
   {
      mode = MODE_IDLE;
      switch(c)
     {
        case '1':
        {
           numboards = 1;
           return 0; 
        }
        case '2':
        {
           numboards = 2;           
           return 0; 
        }
        case '3':
        {
           numboards = 3;          
           return 0; 
        }
        case '4':
        {
           numboards = 4;          
           return 0; 
        }
        case '5':
        {
           numboards = 5;          
           return 0; 
        }       
        case '6':
        {
           numboards = 6;          
           return 0; 
        }  
        case '7':
        {
           numboards = 7;          
           return 0; 
        }  
        case '8':
        {
           numboards = 8;          
           return 0; 
        }  
        case '9':
        {
           numboards = 9;          
           return 0; 
        }  
        case 'A':
        {
           numboards = 10;          
           return 0; 
        }  
        case 'B':
        {
           numboards = 11;          
           return 0; 
        }  
        case 'C':
        {
           numboards = 12;          
           return 0; 
        }  
        case 'D':
        {
           numboards = 13;          
           return 0; 
        }  
        case 'E':
        {
           numboards = 14;          
           return 0; 
        }  
        case 'F':
        {
           numboards = 15;          
           return 0; 
        }  
        case 'G':
        {
           numboards = 16;          
           return 0; 
        }  
        case 'H':
        {
           numboards = 17;          
           return 0; 
        }  
        case 'I':
        {
           numboards = 18;          
           return 0; 
        }          
        default:
        {
           return "invalid setup command"; 
        }break;
     } 
   }
   case MODE_DIAGNOSTIC:
   {
    mode = MODE_IDLE;
    switch(c)
    { 
      case '1':
      {
	   selectBoard(numboards);
       addressU1(true);
       addressU2(true);
       addressU3(true);
       addressU4(true);
       addressU5(true);
	   deselectBoard(numboards);
       return 0;
      }
      default:
      {
       return "Invalid Diagnostic Command";
      }break;      
    }
    return 0;
   }
    default:
    {
      mode = MODE_IDLE;
      return 0;
    }
  }
}
////////////////////////////////////////////////////////////////////
void selectBoard(int i)
{
	if(i == 1)
	{
	 //digitalWrite reset 20 low
	 PORTC &= 0xFB;
	} 
	if(i == 2)
	{
	 //digitalWrite reset 19 low
	 PORTC &= 0xF7;
	} 
	if(i == 3)
	{
	 //digitalWrite reset 18 low
	 PORTC &= 0xEF;
	} 
	if(i == 4)
	{
	 //digitalWrite reset 17 low
	 PORTC &= 0xDF;
	} 
	if(i == 5)
	{
	 //digitalWrite reset 16 low
	 PORTC &= 0xBF;
	} 
	if(i == 6)
	{
	 //digitalWrite reset 15 low
	 PORTC &= 0x7F;
	} 
	if(i == 7)
	{
	 //digitalWrite reset 14 low
	 PORTL &= 0xFE;
	} 
	if(i == 8)
	{
	 //digitalWrite reset 13 low
	 PORTL &= 0xFD;
	} 
	if(i == 9)
	{
	 //digitalWrite reset 12 low
	 PORTL &= 0xFB;
	} 
	if(i == 10)
	{
	 //digitalWrite reset 11 low
	 PORTL &= 0xF7;
	} 
	if(i == 11)
	{
	 //digitalWrite reset 10 low
	 PORTL &= 0xEF;
	} 
	if(i == 12)
	{
	 //digitalWrite reset 9 low
	 PORTL &= 0xDF;
	} 
	if(i == 13)
	{
	 //digitalWrite reset 8 low
	 PORTL &= 0xBF;
	} 
	if(i == 14)
	{
	 //digitalWrite reset 7 low
	 PORTL &= 0x7F;
	} 
	if(i == 15)
	{
	 //digitalWrite reset 6 low
	 PORTA &= 0x7F;
	} 
	if(i == 16)
	{
	 //digitalWrite reset 5 low
	 PORTA &= 0xBF;
	} 
	if(i == 17)
	{
	 //digitalWrite reset 4 low
	 PORTA &= 0xDF;
	} 
	if(i == 18)
	{
	 //digitalWrite reset 3 low
	 PORTA &= 0xEF;
	}        
}
////////////////////////////////////////////////////////////////////
int selectDUT(byte addr)
{
    int returnval = 0;
    int whenRead = 0;

    whenRead = writeToReg(addr);
    delay(100);	// time for the digital switching noise to settle down before we do analog reads
	
    if(whenRead == 1)
    {
	   returnval = 1;
    }      
    
	return returnval; 
}
////////////////////////////////////////////////////////////////////
void deselectBoard(int i)
{
	if(i == 1)
	{
	//digitalWrite reset 20 high
	PORTC |= 0x04;
	} 
	if(i == 2)
	{
	//digitalWrite reset 19 high
	PORTC |= 0x08;
	} 
	if(i == 3)
	{
	//digitalWrite reset 18 high
	PORTC |= 0x10;
	} 
	if(i == 4)
	{
	//digitalWrite reset 17 high
	PORTC |= 0x20;
	} 
	if(i == 5)
	{
	//digitalWrite reset 16 high
	PORTC |= 0x40;
	} 
	if(i == 6)
	{
	//digitalWrite reset 15 high
	PORTC |= 0x80;
	} 
	if(i == 7)
	{
	//digitalWrite reset 14 high
	PORTL |= 0x01;
	} 
	if(i == 8)
	{
	//digitalWrite reset 13 high
	PORTL |= 0x02;
	} 
	if(i == 9)
	{
	//digitalWrite reset 12 high
	PORTL |= 0x04;
	} 
	if(i == 10)
	{
	//digitalWrite reset 11 high
	PORTL |= 0x08;
	} 
	if(i == 11)
	{
	//digitalWrite reset 10 high
	PORTL |= 0x10;
	} 
	if(i == 12)
	{
	//digitalWrite reset 9 high
	PORTL |= 0x20;
	} 
	if(i == 13)
	{
	//digitalWrite reset 8 high
	PORTL |= 0x40;
	} 
	if(i == 14)
	{
	//digitalWrite reset 7 high
	PORTL |= 0x80;
	} 
	if(i == 15)
	{
	//digitalWrite reset 6 high
	PORTA |= 0x80;
	} 
	if(i == 16)
	{
	//digitalWrite reset 5 high
	PORTA |= 0x40;
	} 
	if(i == 17)
	{
	//digitalWrite reset 4 high
	PORTA |= 0x20;
	} 
	if(i == 18)
	{
	//digitalWrite reset 3 high
	PORTA |= 0x10;
	}          
}
////////////////////////////////////////////////////////////////////
double readPosMonitor()
{
    double returnval;
	returnval = analogRead(Pmon);
	returnval = returnval * 0.0000531259;

	return returnval; 
}
////////////////////////////////////////////////////////////////////
double readNegMonitor()
{
	double returnval;
	returnval = analogRead(Nmon);
	returnval = returnval * 0.0000740543;

	return returnval; 
}
////////////////////////////////////////////////////////////////////
int writeToReg(byte data)
{
  int returnval = 0;
  
  //digitalWrite register low
  //digitalWrite Clock low
  PORTC &= 0xFC;
  
  for(int i = 0; i < 8; i++)
  {
     if((data >> 7) > 0)
    {
       //digitalWrite register HIGH
       PORTC |= 0x02; 
    } 
    else
    {
       //digitalWrite register LOW;
       PORTC &= 0xFD;
    }
    //toggle clock
    PORTC &= 0xFE;
    delayMicroseconds(250);
    //delayMicroseconds(1000);
    data = data << 1;
    PORTC |= 0x01;
    delayMicroseconds(250);
    //delayMicroseconds(1000);
    
    if(i == 7)
    {
      returnval = 1;
      return returnval; 
    }
  }
  //digitalWrite register low
  //digitalwrite clock low
    PORTC &= 0xFC;
}
////////////////////////////////////////////////////////////////
byte byteFlip(byte data)
{
 byte temp;
 byte temp1;
 
 temp = data;
 temp = temp >> 7;
 temp = temp & 0x01;
 temp1 = data;
 temp1 = temp1 >> 5;
 temp1 = temp1 & 0x02;
 temp = temp | temp1;
 temp1 = data;
 temp1 = temp1 >> 3;
 temp1 = temp1 & 0x04;
 temp = temp | temp1;
 temp1 = data;
 temp1 = temp1 >> 1;
 temp1 = temp1 & 0x08;
 temp = temp | temp1;
 temp1 = data;
 temp1 = temp1 << 1;
 temp1 = temp1 & 0x10;
 temp = temp | temp1;
 temp1 = data;
 temp1 = temp1 << 3;
 temp1 = temp1 & 0x20;
 temp = temp | temp1;
 temp1 = data;
 temp1 = temp1 << 5;
 temp1 = temp1 & 0x40;
 temp = temp | temp1;
 temp1 = data;
 temp1 = temp1 << 7;
 temp1 = temp & 0x80;
 temp = temp | temp1;
 temp = temp ^ 0xFF;
 return temp;
}
////////////////////////////////////////////////////////////////
double readBit4(void)
{
 double returnval;
 returnval = analogRead(Bit4);
 returnval = returnval / 1024;
 returnval = returnval * 5;
 return returnval; 
}
/////////////////////////////////////////////////////////////////
double readActive(void)
{
 double returnval;
 returnval = analogRead(Active);
 returnval = returnval / 1024;
 returnval = returnval * 5;
 return returnval; 
}
////////////////////////////////////////////////////////////////
void addressU1(boolean diagFlag)
{ 
  byte addr_in;
  byte address = 0x20;
  int socket;
  int mux = 0;
   
  for(int i=1; i < 5; i++)
  {
    if(i == 1)
    {
      addr_in = byteFlip(address);
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());
      Serial.print("\n");
    }
    else
    {
      if(i == 2)
      {
        mux = 1;
      }
      if(i == 3)
      {
       mux = -1; 
      }
      if(i ==4)
      {
       mux = 0; 
      }
      address = address + 0x40;
      addr_in = byteFlip(address);     
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());
      Serial.print("\n");
      
    }
  } 
}
////////////////////////////////////////////////////////////////
byte addressU2(boolean diagFlag)
{ 
  byte addr_in;
  byte address = 0x10;
  int socket;
  int mux = 4;
  
  for(int i=1; i < 5; i++)
  {
    if(i == 1)
    {
      addr_in = byteFlip(address);
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());
      Serial.print("\n");
    }
    else
    {
      if(i == 2)
      {
        mux = 5;
      }
      if(i == 3)
      {
       mux = 3; 
      }
      if(i ==4)
      {
       mux = 4; 
      }      
      address = address + 0x40;
      addr_in = byteFlip(address);     
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());      
      Serial.print("\n");
      
    }
  }
}
////////////////////////////////////////////////////////////////////////////
byte addressU3(boolean diagFlag)
{
  byte addr_in;
  byte address = 0x08;
  int socket;
  int mux = 8;
  
  for(int i=1; i < 5; i++)
  {
    if(i == 1)
    {
      addr_in = byteFlip(address);
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());      
      Serial.print("\n");
    }
    else
    {
      if(i == 2)
      {
        mux = 9;
      }
      if(i == 3)
      {
       mux = 7; 
      }
      if(i ==4)
      {
       mux = 8; 
      }  
      address = address + 0x40;
      addr_in = byteFlip(address);     
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());      
      Serial.print("\n");
      
    }
 }
}
//////////////////////////////////////////////////////////////////////
byte addressU4(boolean diagFlag)
{ 
  byte addr_in;
  byte address = 0x04;
  int socket;
  int mux = 12;
  
  for(int i=1; i < 5; i++)
  {
    if(i == 1)
    {
      addr_in = byteFlip(address);
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());      
      Serial.print("\n");
    }
    else
    {
      if(i == 2)
      {
        mux = 13;
      }
      if(i == 3)
      {
       mux = 11; 
      }
      if(i ==4)
      {
       mux = 12; 
      }        
      address = address + 0x40;
      addr_in = byteFlip(address);     
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());      
      Serial.print("\n");
      
    }
  }
}
///////////////////////////////////////////////////////////////////////
byte addressU5(boolean diagFlag)
{
  byte addr_in;
  byte address = 0x02;
  int socket;
  int mux = 16;
  
  for(int i=1; i < 5; i++)
  {
    if(i == 1)
    {
      addr_in = byteFlip(address);
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());      
      Serial.print("\n");
     }
    else
    {
      if(i == 2)
      {
        mux = 17;
      }
      if(i == 3)
      {
       mux = 15; 
      }
      if(i ==4)
      {
       mux = 16; 
      }  
      address = address + 0x40;
      addr_in = byteFlip(address);     
      Serial.print(numboards, DEC);
      Serial.print(",");
      socket = mux + i;
      Serial.print(socket, DEC);
      Serial.print(",");
      selectDUT(addr_in);
      Serial.print(readPosMonitor(), 3);
      Serial.print(",");
      Serial.print(readNegMonitor(), 3);
      Serial.print(",");
      Serial.print(readBit4());
      Serial.print(",");
      Serial.print(readActive());      
      Serial.print("\n");
      
    }
  }
}
////////////////////////////////////////////////////////////////
void loop()
{
  // run the state machine
  char * errMsg = proc();
  // OK?
  if(!errMsg)
  {
   return; 
  }
  mode = MODE_IDLE;
  Serial.print(errMsg);
  Serial.println();
}
