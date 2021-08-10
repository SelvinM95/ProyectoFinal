using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProyecto.Models
{
    public class Archivo
    {
        public int idFile { get; set; }

        public int idTeam { get; set; }

        public int idUser { get; set; }

        public string teamName { get; set; }

        public string nameUser { get; set; }

        public string fileName { get; set; }

        public string fileType { get; set; }

        public string filePath { get; set; }

        public DateTime uploadDate { get; set; }

        public string icon { get; set; }
    }
}
