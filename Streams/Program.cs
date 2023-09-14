using System.IO;


//Writing
/*FileStream fin = new FileStream("myfile.txt",FileMode.Create);
for(int i = 65; i < 91; i++)
{
    fin.WriteByte((byte)(i));
    fin.WriteByte((byte)' ');
}
fin.Close();*/

//Reading
/*int x;
FileStream fout = new FileStream("myfile.txt", FileMode.Open);
while ((x=fout.ReadByte())!=-1)
{
    Console.WriteLine((char)x);

}*/


FileStream open = new FileStream("myfile.txt", FileMode.Open);
FileStream copy = new FileStream("myfilecopy.txt", FileMode.Create);

int x;

while ((x = open.ReadByte()) != -1)
{
    Console.WriteLine((char)x);
    copy.WriteByte((byte)(x));
}

