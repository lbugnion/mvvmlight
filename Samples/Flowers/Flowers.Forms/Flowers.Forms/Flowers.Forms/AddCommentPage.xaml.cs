using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flowers.Data.ViewModel;

namespace Flowers.Forms
{
    public partial class AddCommentPage
    {
        public FlowerViewModel Vm
        {
            get
            {
                return (FlowerViewModel)BindingContext;
            }
        }

        public AddCommentPage(FlowerViewModel flower)
        {
            InitializeComponent();

            BindingContext = flower;

            Vm.SaveCommentCommand.CanExecuteChanged += (s, e) => CheckSaveCommentEnabled();
            CheckSaveCommentEnabled();

            SaveCommentButton.Clicked += (s, e) =>
            {
                Vm.SaveCommentCommand.Execute(CommentText.Text);
            };

            CommentText.TextChanged += (s, e) =>
            {
                CheckSaveCommentEnabled();
            };
        }

        private void CheckSaveCommentEnabled()
        {
            SaveCommentButton.IsEnabled = Vm.SaveCommentCommand.CanExecute(CommentText.Text);
        }
    }
}
