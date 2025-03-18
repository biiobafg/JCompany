using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace JCompany.Model
{
    public class Item
    {
        public Item(string? eng, string dat)
        {
            this.EngPath = eng;
            this.DatPath = dat;

            



            
            if (this.SearchDat("Guid", out string? Tguid))
                this.GUID = Tguid;
            if (this.SearchDat("Type", out string? Ttype))
                Type = Ttype.ToLower();
            if (this.SearchDat("ID", out string? Tid))
                Id = Tid;
            if (this.SearchEng("Name", out string? Tname))
                Name = Tname;
            else // quick fix for naming effects / spawntables that dont contain a whatyamacallit
                Name = Ttype;
        }
        public string? Name { get; set; }
        public string? GUID { get; set; }
        public string? Type { get; set; }
        // this should be stored as a ushort (since that's what it is in unturned) but then if its over 65535 or whatever it'll break - simple solution, Make it a string
        public string? Id { get; set; }
        // this is nullable since Effects dont use English.dat files
        public string? EngPath { get; set; }
        public string DatPath { get; set; }
        public bool Modified { get; set; }
        // not null = overlapping with something
        public List<Item>? Overlap { get; set; }


        // should implement a list of stuff this is used to craft in, Calibers etc but that'll come later
    }

}
