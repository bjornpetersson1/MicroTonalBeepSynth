using System.Security.Claims;

static List<int> GenerateScale(int antalToner = 7)
{
    Random random = new Random();
    int[] kromatiskaSkalan = new int[12];
    kromatiskaSkalan[0] = 440;
    kromatiskaSkalan[1] = 466;
    kromatiskaSkalan[2] = 494;
    kromatiskaSkalan[3] = 523;
    kromatiskaSkalan[4] = 554;
    kromatiskaSkalan[5] = 587;
    kromatiskaSkalan[6] = 622;
    kromatiskaSkalan[7] = 659;
    kromatiskaSkalan[8] = 698;
    kromatiskaSkalan[9] = 740;
    kromatiskaSkalan[10] = 784;
    kromatiskaSkalan[11] = 831;

    HashSet<int> randomResult = new HashSet<int>();
    while (randomResult.Count < antalToner)
    {
        int randomNumber = random.Next(0, 12);
        randomResult.Add(randomNumber);
    }

    int grundtonOktava = 0;
    List<int> tonMaterial = new List<int>();
    List<int> skalResult = new List<int>(randomResult);
    List<string> tonNamn = new List<string>();
    for (int i = 0; i < antalToner; i++)
    {
        int microShift = random.Next(0, 16);
        int plusMinus = random.Next(0, 3);
        int tonMicroshift = 0;
        if (plusMinus == 0)
        {
            tonMicroshift = kromatiskaSkalan[skalResult[i]] - microShift;
            //Console.WriteLine(skalResult[i] + " - " + microShift + " hz");
        }
        if (plusMinus == 1)
        {
            tonMicroshift = kromatiskaSkalan[(int)skalResult[i]] + microShift;
            //Console.WriteLine(skalResult[i] + " + " + microShift + " hz");
        }
        if (plusMinus == 2)
        {
            tonMicroshift = kromatiskaSkalan[skalResult[i]];
            //Console.WriteLine(skalResult[i]);
        }
        if (i == 0)
        {
            grundtonOktava = tonMicroshift*2;
        }
        tonMaterial.Add(tonMicroshift);
        switch (skalResult[i])
        {
            case 0:
                tonNamn.Add("A");
                break;
            case 1:
                tonNamn.Add("Bb");
                break;
            case 2:
                tonNamn.Add("B");
                break;
            case 3:
                tonNamn.Add("C");
                break;
            case 4:
                tonNamn.Add("Db");
                break;
            case 5:
                tonNamn.Add("D");
                break;
            case 6:
                tonNamn.Add("Eb");
                break;
            case 7:
                tonNamn.Add("E");
                break;
            case 8:
                tonNamn.Add("F");
                break;
            case 9:
                tonNamn.Add("Gb");
                break;
            case 10:
                tonNamn.Add("G");
                break;
            case 11:
                tonNamn.Add("Ab");
                break;
            default:
                break;
        }
    }
    skalResult.Sort();
    tonMaterial.Sort();
    tonMaterial.Add(tonMaterial[0] * 2);
    return tonMaterial;
}

static void DrawKeysAndMenu(int octave)
{
    static void DrawOctave(int octave)
    {
        if (octave == -2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| * | * | - | - |   |   | * | * |");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (octave == -1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| * | * |   | - |   |   | * | * |");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (octave == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| * | * |   |   |   |   | * | * |");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (octave == 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| * | * |   |   | + |   | * | * |");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (octave == 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| * | * |   |   | + | + | * | * |");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    Console.Clear();
    Console.WriteLine("Press P to play the scale");
    Console.WriteLine("Press 0 to generate new scale");
    Console.WriteLine("Press + to go up an octave");
    Console.WriteLine("Press - to go down an octave");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("| 1 | 2 | 3 | 4 | 5 | 6 | 7 | 1'|");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("|^^^|^^^|^^^|^^^|^^^|^^^|^^^|^^^|");
    Console.WriteLine("| a | s | d | f | h | j | k | l |");
    Console.WriteLine("|___|___|___|___|___|___|___|___|");
    DrawOctave(octave);
    Console.WriteLine();
    Console.WriteLine("Play something BEAUTIFUL!!");
}
static void PlaySynth(List<int> OneOctaveScale, int duration = 500)
{
    int octaveIs = 0;
    DrawKeysAndMenu(octaveIs);
    while (true)
    {
        Console.CursorVisible = false;
        ConsoleKeyInfo press = Console.ReadKey(true);
        if (press.Key == ConsoleKey.A) Console.Beep(OneOctaveScale[0], duration);
        if (press.Key == ConsoleKey.S) Console.Beep(OneOctaveScale[1], duration);
        if (press.Key == ConsoleKey.D) Console.Beep(OneOctaveScale[2], duration);
        if (press.Key == ConsoleKey.F) Console.Beep(OneOctaveScale[3], duration);
        if (press.Key == ConsoleKey.H) Console.Beep(OneOctaveScale[4], duration);
        if (press.Key == ConsoleKey.J) Console.Beep(OneOctaveScale[5], duration);
        if (press.Key == ConsoleKey.K) Console.Beep(OneOctaveScale[6], duration);
        if (press.Key == ConsoleKey.L) Console.Beep(OneOctaveScale[7], duration);
        if (press.Key == ConsoleKey.P)
        {
            for (global::System.Int32 i = 0; i < OneOctaveScale.Count; i++)
            {
                Console.Clear();
                Console.WriteLine(i+1);
                Console.Beep(OneOctaveScale[i], duration);
                Thread.Sleep(duration+200);

            }
            if (octaveIs == 2)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == 1)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == 0)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == -1)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == -2)
            {
                DrawKeysAndMenu(octaveIs);
            }

        }
        if (press.Key == ConsoleKey.OemPlus)
        {
            if (octaveIs == 2) continue;
            for (global::System.Int32 i = 0; i < OneOctaveScale.Count; i++)
            {
                OneOctaveScale[i] *= 2;
            }
            octaveIs++;
            if (octaveIs == 1)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == 2)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == 0)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == -1)
            {
                DrawKeysAndMenu(octaveIs);
            }
        }
        if (press.Key == ConsoleKey.OemMinus)
        {
            if (octaveIs == -2) continue;
            for (global::System.Int32 i = 0; i < OneOctaveScale.Count; i++)
            {
                OneOctaveScale[i] /= 2;
            }
            octaveIs--;
            if (octaveIs == -1)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == -2)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == 0)
            {
                DrawKeysAndMenu(octaveIs);
            }
            else if (octaveIs == 1)
            {
                DrawKeysAndMenu(octaveIs);
            }
        }
        if (press.Key == ConsoleKey.D0)
        {
            OneOctaveScale = GenerateScale();
            Console.Clear();
            Console.WriteLine("generating new microtonal scale...");
            Thread.Sleep(1500);
            octaveIs = 0;
            DrawKeysAndMenu(octaveIs);
        }
    }
}

PlaySynth(GenerateScale());