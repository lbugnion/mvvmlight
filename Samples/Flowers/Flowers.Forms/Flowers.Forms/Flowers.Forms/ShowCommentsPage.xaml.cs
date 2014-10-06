using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flowers.Data.ViewModel;

namespace Flowers.Forms
{
    public partial class ShowCommentsPage
    {
        public ShowCommentsPage(FlowerViewModel flower)
        {
            InitializeComponent();

            BindingContext = flower;
            PageTitle.Text = "Comments for " + flower.Model.Name;
        }
    }
}
