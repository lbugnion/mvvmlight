// ****************************************************************************
// <copyright file="Settings.SL.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>15.10.2009</date>
// <project>CleanShutdown</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System.IO;
using System.Windows.Media;

namespace CleanShutdown.Helpers
{
    public partial class Settings
    {
        private const string ApplicationBackgroundBrushKey = "ApplicationBackgroundBrush";

        private const char Separator = ';';

        public static Settings Deserialize(Stream fromStream)
        {
            var settings = new Settings();

            using (var reader = new StreamReader(fromStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    switch (line)
                    {
                        case ApplicationBackgroundBrushKey:
                            settings.ApplicationBackgroundBrush = GetSolidColorBrush(reader.ReadLine());
                            break;
                    }
                }
            }

            return settings;
        }

        public static void Serialize(Settings settings, Stream toStream)
        {
            // We only handle SolidColorBrush here
            var brush = (SolidColorBrush) settings.ApplicationBackgroundBrush;

            using (var writer = new StreamWriter(toStream))
            {
                writer.WriteLine(ApplicationBackgroundBrushKey);
                writer.Write(brush.Color.R);
                writer.Write(Separator);
                writer.Write(brush.Color.G);
                writer.Write(Separator);
                writer.Write(brush.Color.B);
            }
        }

        private static Brush GetSolidColorBrush(string line)
        {
            var bytes = line.Split(new[]
            {
                Separator
            });

            var color = Color.FromArgb(
                255,
                byte.Parse(bytes[0]),
                byte.Parse(bytes[1]),
                byte.Parse(bytes[2]));

            return new SolidColorBrush(color);
        }
    }
}