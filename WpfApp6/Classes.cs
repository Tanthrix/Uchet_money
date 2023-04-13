using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    static class TypesPicker
    {
        public static void addType(string t_)
        {
            List<string> types = JSONParse.Des<List<string>>(Configs.typepath);
            types.Add(t_);
            JSONParse.Ser(Configs.typepath, types);
        }
    }
    static class NotePicker
    {
        private static Dictionary<string, List<Note>> getNotes()
        {
            Dictionary<string, List<Note>> notes = JSONParse.Des<Dictionary<string, List<Note>>>(Configs.notepath);
            return notes;
        }
        public static void addDate(DateTime? pickedDate)
        {
            var notes = getNotes();
            if (notes.ContainsKey(pickedDate.ToString())) return;
            notes[pickedDate.ToString()] = new List<Note>();
            JSONParse.Ser(Configs.notepath, notes);
        }
        public static void newNote(DateTime? pickedDate, Note note)
        {
            var notes = getNotes();
            var todayNotes = notes[pickedDate.ToString()];
            todayNotes.Add(note);
            notes[pickedDate.ToString()] = todayNotes;
            JSONParse.Ser(Configs.notepath, notes);
        }
        public static void editNote(DateTime? pickedDate, Note note, int index)
        {
            var notes = getNotes();
            var todayNotes = notes[pickedDate.ToString()];
            todayNotes[index] = note;
            notes[pickedDate.ToString()] = todayNotes;
            JSONParse.Ser(Configs.notepath, notes);
        }
        public static void delNote(DateTime? pickedDate, int index)
        {
            var notes = getNotes();
            var todayNotes = notes[pickedDate.ToString()];
            todayNotes.RemoveAt(index);
            notes[pickedDate.ToString()] = todayNotes;
            JSONParse.Ser(Configs.notepath, notes);
        }
        public static double[] checkOut(DateTime? pickedDate)
        {
            double[] response = new double[2];
            double day = 0, all = 0;
            var notes = getNotes();
            foreach (string key in notes.Keys)
            {
                List<Note> curNotes = notes[key];
                double selectedCount = 0;
                foreach (Note curNote in curNotes)
                {
                    if (curNote.isIncome)
                    {
                        selectedCount += curNote.money;
                    }
                    else
                    {
                        selectedCount -= curNote.money;
                    }

                }
                if (key == pickedDate.ToString())
                {
                    day = selectedCount;
                }
                all += selectedCount;
            }
            response = new double[] { day, all };
            return response;
        }
    }
    class Note
    {
        public string name { get; set; } = "";
        public string typeName { get; set; } = "";
        private double money2 { get; set; }
        public double money
        {
            get
            {
                return money2;
            }
            set
            {
                money2 = value;
                if (value < 0)
                {
                    isIncome = false;
                    money2 = value * -1.0;
                }
                else
                {
                    isIncome = true;
                }
            }
        }
        public bool isIncome { get; set; }
        public Note() { }
        public Note(string name, string typeName, double money)
        {
            this.name = name;
            this.typeName = typeName;
            this.money = money;
        }
    }

}
