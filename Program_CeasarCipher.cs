#region var
const string ENCRYPT = "encrypt";
const string DECRYPT = "decrypt";

char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToArray();
#endregion

#region program
bool decision = DecisionEncodeOrDecode();
int shift = AskForShift();
if (decision)
{
    Console.WriteLine($"Your {ENCRYPT}ed output: {EncryptDecrypt(shift, AskForInput(ENCRYPT), alphabet)}");
}
else
{ 
    Console.WriteLine($"Your {DECRYPT}d output: {EncryptDecrypt(shift, AskForInput(DECRYPT), alphabet)}");
}
#endregion

#region method
bool DecisionEncodeOrDecode()
{
    string decision;
    do{
    Console.Write("Do you want to encode[e] or decode[d]? ");
    decision = Console.ReadLine()!.ToLower();
    }while (decision != "e" && decision != "d");
    return decision == "e";
}
int AskForShift()
{
    string valueString;
   do
    {
        Console.Write("What shift do you want to use? Use - before the number for a left shift. The number has to be between -25 und 25: ");
        valueString = Console.ReadLine()!;
    } while (!int.TryParse(valueString, out int result) || int.Parse(valueString) > 25 || int.Parse(valueString) < -25 || int.Parse(valueString) == 0);
    return int.Parse(valueString); 
}
string EncryptDecrypt(int shift, string input, char[] alphabet)
{
    string Output = "";
    for (int i = 0; i < input.Length; i++)
    {
        if (char.IsLetter(input[i]))
        {
            int letterIndexAlphabet = Array.IndexOf(alphabet, input[i]);
            if (char.IsUpper(input[i]))
            {Output += alphabet[(letterIndexAlphabet + shift + 26) % 26].ToString().ToUpper();}
            else { Output += alphabet[(letterIndexAlphabet + shift + 26) % 26];}
        }
        else
        {Output += input[i];}
    }

    return Output;
}
string AskForInput(string encryptDecrypt)
{
    Console.Write($"what do you want to {encryptDecrypt}? ");
    return Console.ReadLine()!;
}
#endregion
