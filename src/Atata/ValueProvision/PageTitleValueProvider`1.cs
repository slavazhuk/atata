﻿namespace Atata
{
    public class PageTitleValueProvider<TOwner> : IUIComponentValueProvider<string, TOwner>
        where TOwner : PageObject<TOwner>
    {
        private readonly TOwner pageObject;

        public PageTitleValueProvider(TOwner pageObject)
        {
            this.pageObject = pageObject;
        }

        string IUIComponentValueProvider<string, TOwner>.ComponentFullName
        {
            get { return pageObject.ComponentFullName; }
        }

        TOwner IUIComponentValueProvider<string, TOwner>.Owner
        {
            get { return pageObject; }
        }

        string IUIComponentValueProvider<string, TOwner>.ProviderName
        {
            get { return "title"; }
        }

        string IUIComponentValueProvider<string, TOwner>.ConvertValueToString(string value)
        {
            return value;
        }

        public string Get()
        {
            return pageObject.Driver.Title;
        }
    }
}