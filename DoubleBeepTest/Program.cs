using System;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        Random random = new Random();
        float[] chordFrequencies = new float[4];
        while (true)
        {
            for (int i = 0; i < chordFrequencies.Length; i++)
            {
                chordFrequencies[i] = (float)random.NextDouble()*800+300;
            }
            // Definiera frekvenser för ett C-dur-ackord: C (261.63), E (329.63), G (392.00)

            var providers = new List<ISampleProvider>();

            foreach (var freq in chordFrequencies)
            {
                var sine = new SignalGenerator()
                {
                    Gain = 0.4,              // volym per ton (för att undvika distorsion)
                    Frequency = freq,
                    Type = SignalGeneratorType.Triangle
                }.Take(TimeSpan.FromSeconds(2)); // spela varje ton i 2 sekunder

                providers.Add(sine);
            }

            var mixer = new MixingSampleProvider(providers);
            mixer.ReadFully = true;

            using (var output = new WaveOutEvent())
            {
                output.Init(mixer);
                output.Play();
                while (output.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100); // Vänta tills ljudet spelats upp
                }
            }            
        }
    }
}

