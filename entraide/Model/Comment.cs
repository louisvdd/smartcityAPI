using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comment
    {
        public long Id { get; set; }
        public string CommentDescription { get; set; }
        public double Rating { get; set; }
    }
}