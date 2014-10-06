using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Flowers.Data.Model;

namespace Flowers.Data.Design
{
    // This class is used in the Windows Phone app at design time,
    // for the Blend visual designer.
    public class DesignFlowersService : IFlowersService
    {
        public Task<IList<Flower>> Refresh()
        {
            var list = new List<Flower>();

            for (var index = 0; index < 20; index++)
            {
                list.Add(GetFlower(index));
            }

            return Task.FromResult((IList<Flower>)list);
        }

        public Task<bool> Save(Flower flower)
        {
            return null;
        }

        public Flower GetFlower(int index)
        {
            return new Flower
            {
                Name = "Flower # " + index,
                Description =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Image = "http://www.galasoft.ch/labs/flowers/design/flowericon.png",
                Comments = new ObservableCollection<Comment>
                {
                    new Comment
                    {
                        Id = index + "A",
                        InputDate = (DateTime.Now - TimeSpan.FromHours(3.5)),
                        Text = "This is a comment"
                    },
                    new Comment
                    {
                        Id = index + "B",
                        InputDate = (DateTime.Now - TimeSpan.FromHours(4.7)),
                        Text = "This is another comment which I hope will span on two lines"
                    },
                }
            };
        }
    }
}