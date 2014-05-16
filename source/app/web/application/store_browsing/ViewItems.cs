using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.core;

namespace app.web.application.store_browsing
{
    public class ViewItem<Item> : ISupportAUserFeature
    {
        IGetItems<Item> items;
        IRenderInformation response;
        IGetTheParentCategory parent;

        public ViewItem(IGetItems<Item> items, IRenderInformation response, IGetTheParentCategory parent)
        {
            this.items = items;
            this.response = response;
            this.parent = parent;
        }

        public void process(IProvideDetailsAboutTheRequest request)
        {
            var results = items.get_items(parent);
            response.display(results);
        }

    }
}
