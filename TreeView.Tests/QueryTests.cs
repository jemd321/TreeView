namespace TreeView.Tests
{
#pragma warning disable SA1600 // Elements should be documented
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void GetAllItems_OneCategories_GetsAllItems()
        {
            var categories = new List<Category>()
            {
                CreateTestCategory(),
            };

            List<Item> result = Queries.GetAllItems(categories);

            Assert.IsTrue(result.Count == 2);
        }

        [TestMethod]
        public void GetAllItems_MultipleCategories_GetsAllItems()
        {
            var categories = new List<Category>()
            {
                CreateTestCategory(),
                CreateTestCategory(),
            };

            List<Item> result = Queries.GetAllItems(categories);

            Assert.IsTrue(result.Count == 4);
        }

        private static Category CreateTestCategory()
        {
            var category = new Category("root1");
            RootFolder root1 = category.RootFolder;
            root1.AddItem(new Item(root1, "item1"));
            root1.AddFolder(new Folder(root1, "folder1"));
            Folder folder1 = root1.ChildFolders.Single();
            folder1.AddItem(new Item(folder1, "item2"));
            return category;
        }
    }
}
