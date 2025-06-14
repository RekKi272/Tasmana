using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Notice
    {
        public int STT { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string FileExten { get; set; }
        public bool Priority { get; set; }
        public List<Division> Divisions { get; set; }
        public List<Group> Groups { get; set; }
        public List<Employee> Employees { get; set; }

        public Notice(int stt, string title, string content, DateTime date, string author, byte[] file, string fileName, string fileExten, bool priority, List<Division> division, List<Group> group, List<Employee> employee)
        {
            this.STT = stt;
            this.Title = title;
            this.Content = content;
            this.Date = date;
            this.Author = author;
            this.File = file;
            this.FileName = fileName;
            this.FileExten = fileExten;
            this.Priority = priority;
            this.Divisions = division;
            this.Groups = group;
            this.Employees = employee;
        }
        public Notice(int stt, string title, string content, DateTime date, string author, byte[] file, string fileName, string fileExten, bool priority)
        {
            this.STT = stt;
            this.Title = title;
            this.Content = content;
            this.Date = date;
            this.Author = author;
            this.File = file;
            this.FileName = fileName;
            this.FileExten = fileExten;
            this.Priority = priority;
        }
        public Notice(int stt, string title, string content, DateTime date, string author, bool priority)
        {
            this.STT = stt;
            this.Title = title;
            this.Content = content;
            this.Date = date;
            this.Author = author;
            this.Priority = priority;
        }

    }
}
