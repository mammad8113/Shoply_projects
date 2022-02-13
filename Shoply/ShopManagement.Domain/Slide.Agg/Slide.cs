using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Slide.Agg
{
    public class Slide:EntityBase<long>
    {
        public string Picture { get;private set; }
        public string PictureAlt { get;private set; }
        public string PictureTitle { get;private set; }
        public string Heding { get;private set; }
        public string Title { get;private set; }
        public string Text { get;private set; }
        public string BtnText { get;private set; }
        public bool IsRemove { get; private set; }

        public Slide(string picture, string pictureAlt, string pictureTitle, string heding, string title, string text, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heding = heding;
            Title = title;
            Text = text;
            BtnText = btnText;
            IsRemove = false;
        }

        public void Edit(string picture, string pictureAlt, string pictureTitle, string heding, string title, string text, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heding = heding;
            Title = title;
            Text = text;
            BtnText = btnText;
          
        }
        public void Remove()
        {
            IsRemove = true;
        }
        public void Activate()
        {
            IsRemove = false;
        }
    }
}
