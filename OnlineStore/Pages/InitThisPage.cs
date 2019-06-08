using OnlineStore.Pages;
using OnlineStore.WrapperFactory;
using SeleniumExtras.PageObjects;

namespace OnlineStore.PageObjects
{
    public static class InitThisPage
    {
        /**
         Instead of doing PageFactory.InitElement on every single page, 
            We can create a static class with a static Generic method which will 
            take our Pages as a parameter and initalise them for us. 
            
            ----------------------------------------------------------------------------------------------
            1. Generics are thread safe e.g a List<string> is guaranteed to be a list of strings
            2. All methods in a static class must be static
            3. Static classes are sealed i.e. can't be inherited. Include them as namespace to use them
           -----------------------------------------------------------------------------------------------
            When to use Static?
            1. When you need a utility class that doesn't change state of an object, states are determined by the object's fields i.e. its' variable/s
        */

        /*
            The Where is a clause. Where is used to specify a condition to our Generic type
            Here we're saying T must have a default parameterless contructor. C# Generates a default paramterless if none is specified
            Why? Because constructors are used to initiazlise pages and/or page objects. BUT we want initizalise them here
            Hence why we need to make sure what we pass into GetPage method hasn't already been initiazlied :)

         */
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static HomePage HomePage
        {
            get { return GetPage<HomePage>(); }
        }

        public static LoginPage LoginPage
        {
            get { return GetPage<LoginPage>(); }
        }

    }
}