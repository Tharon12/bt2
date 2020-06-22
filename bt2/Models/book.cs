using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace bt2.Models
{
    public class book
    {
        private int id;
        private string title;
        private string author;
        private string img_cover;
        public book() { }
        public book(int id, string title, string author, string img_cover) 
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.img_cover = img_cover;
        }
        public int Id
        {
            get{ return id; }
            set { id = value; }
        }
        [Required(ErrorMessage ="phai nhap tieu de")]
        [StringLength(250, ErrorMessage ="khong nhap qua 250 ky tu")]
        [Display(Name ="Tieu de")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Img_cover
        {
            get { return img_cover; }
            set { img_cover = value; }
        }
    }

}