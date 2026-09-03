float myFloatValue = 10;
int myIntValue = (int)myFloatValue;
Console.WriteLine($"myIntValue is {myIntValue}.");

int myInt = 10;
byte myByte = (byte)myInt;
double myDouble = (double)myByte;
bool myBool = (bool)myDouble;//
string myString = "false";
myBool = (bool)myString;//
myString = (string)myInt; // 
myString = myInt.ToString();
myBool = (bool)myByte;//
myByte = (byte)myBool;//
short myShort = (short)myInt;
char myChar = 'X';
myString = (string)myChar;//
long myLong = (long)myInt;
decimal myDecimal = (decimal)myLong;
myString = myString + myInt + myByte + myDouble + myChar;