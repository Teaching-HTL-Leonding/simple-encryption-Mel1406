#region var
const string ENCRYPT = "encrypt";
const string DECRYPT = "decrypt";

char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToArray();
#endregion

#region program
bool decision = DecisionEncodeOrDecode();
if (decision)
{
    string input = AskForInput(ENCRYPT);
    string keyword = AskForKeyword(input);
    Console.WriteLine($"Your {ENCRYPT}ed output: {EncryptDecrypt(keyword, input, alphabet, true)}");
}
else
{
    string input = AskForInput(DECRYPT);
    string keyword = AskForKeyword(input);
    Console.WriteLine($"Your {DECRYPT}d output: {EncryptDecrypt(keyword, input, alphabet, false)}");
}
#endregion

#region method
bool DecisionEncodeOrDecode()
{
    string decision;
    do
    {
        Console.Write("Do you want to encode[e] or decode[d]? ");
        decision = Console.ReadLine()!.ToLower();
    } while (decision != "e" && decision != "d");
    return decision == "e";
}
string AskForKeyword(string input)
{
    string keyword;
    string returnKeyword = "";
    do
    {
        Console.Write("Please enter a keyword. Letters only! ");
        keyword = Console.ReadLine()!.ToLower();
    } while (!keyword.All(Char.IsLetter));
    for(int i = 0, j = 0; i < input.Length; i++, j++)
    {
        if (j == keyword.Length) {j = 0;}
        returnKeyword += keyword[j];
    }
    return returnKeyword;
}

string EncryptDecrypt(string keyword, string input, char[] alphabet, bool encode)
{
    string Output = "";
    for (int i = 0, j = 0; i < input.Length; i++, j++)
    {
        if (alphabet.Contains(char.Parse(input[i].ToString().ToLower())))
        {
            if (char.IsUpper(input[i]))
            { Output += alphabet[GetShiftedPositionInAlphabet(keyword[j], char.Parse(input[i].ToString().ToLower()), alphabet, encode)].ToString().ToUpper(); }
            else { Output += alphabet[GetShiftedPositionInAlphabet(keyword[j], char.Parse(input[i].ToString().ToLower()), alphabet, encode)]; }
        }
        else
        { Output += input[i]; j--;}
    }
    return Output;
}
int GetShiftedPositionInAlphabet(char keyword, char character, char[] alphabet, bool encode)
{
    int letterIndexCharacter = Array.IndexOf(alphabet, character);
    int letterIndexKeyword = Array.IndexOf(alphabet, keyword);
    if (!encode) { letterIndexKeyword *= -1; }
    return (26 + letterIndexCharacter + letterIndexKeyword) % 26;
}
string AskForInput(string encryptDecrypt)
{
    Console.Write($"what do you want to {encryptDecrypt}? ");
    return Console.ReadLine()!;
}
#endregion