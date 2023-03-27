using System.Text.RegularExpressions;

namespace TreeView.Tests
{
#pragma warning disable SA1600 // Elements should be documented
    [TestClass]
    public class FolderTests
    {
        [TestMethod]
        public void AddItem_Item_AddsCorrectly()
        {
            Folder testFolder = CreateEmptyTestFolder();

            testFolder.AddItem(new Item(testFolder, "testItem"));

            Assert.IsTrue(testFolder.ChildItems.Count() == 1);
        }

        [TestMethod]
        public void AddItems_Items_AddsCorrectly()
        {
            Folder testFolder = CreateEmptyTestFolder();
            var item1 = new Item(testFolder, "testItem1");
            var item2 = new Item(testFolder, "testItem1");
            var items = new List<Item>() { item1, item2, };

            testFolder.AddItems(items);

            Assert.IsTrue(testFolder.ChildItems.Count() == 2);
        }

        [TestMethod]
        public void Delete_Self_DeletesSelf()
        {
            Folder testFolder = CreateEmptyTestFolder();

            testFolder.Delete();

            Assert.IsFalse(testFolder.Parent.ChildFolders.Any());
        }

        [TestMethod]
        public void Delete_Self_DeletesChildren()
        {
            Folder testFolder = CreateEmptyTestFolder();

            testFolder.Delete();

            Assert.IsFalse(testFolder.ChildFolders.Any());
        }

        [TestMethod]
        public void DeleteItem_Item_DeletesItem()
        {
            Folder testFolder = CreateEmptyTestFolder();
            var item1 = new Item(testFolder, "testItem1");
            testFolder.AddItem(item1);

            testFolder.DeleteItem(item1);

            Assert.IsFalse(testFolder.ChildItems.Any());
        }

        [TestMethod]
        public void DeleteItem_Items_DeletesCorrectItem()
        {
            Folder testFolder = CreateEmptyTestFolder();
            var item1 = new Item(testFolder, "testItem1");
            var item2 = new Item(testFolder, "testItem2");
            testFolder.AddItem(item1);
            testFolder.AddItem(item2);

            testFolder.DeleteItem(item1);

            Assert.IsTrue(testFolder.ChildItems.Count() == 1);
            Assert.IsFalse(testFolder.ChildItems.Contains(item1));
            Assert.IsTrue(testFolder.ChildItems.Contains(item2));
        }

        [TestMethod]
        public void Move_ToADestinationFolder_MovesCorrectly()
        {
            Folder testFolder = CreateEmptyTestFolder();
            var destinationFolder = new Folder(null, "destinationFolder");

            testFolder.Move(destinationFolder);

            Assert.IsTrue(destinationFolder.ChildFolders.Any());
        }

        [TestMethod]
        public void Move_ToADestinationFolderWithChildren_MovesAllCorrectly()
        {
            Folder testFolder = CreateEmptyTestFolder();
            Folder destinationFolder = SetupDestinationFolder();
            testFolder.AddItem(new Item(testFolder, "testItem"));

            testFolder.Move(destinationFolder);

            Assert.IsTrue(destinationFolder.ChildFolders.Single().ChildItems.Any());
        }

        [TestMethod]
        public void Search_SingleItemMatchingRegex_FindsMatch()
        {
            (Folder testFolder, Item testItem) = CreateTestFolderWithOneItem();
            const string REGEXPATTERN = "testItem";
            var searchRegex = new Regex(REGEXPATTERN);

            SearchResult searchResult = testFolder.Search(searchRegex);

            Assert.IsTrue(searchResult.ResultFound);
            Assert.IsTrue(searchResult.FoundItems.Single().Name == testItem.Name);
            Assert.IsFalse(searchResult.FoundFolders.Any());
        }

        [TestMethod]
        public void Search_SingleItemMatchingWildCardRegex_FindsMatch()
        {
            (Folder testFolder, Item testItem) = CreateTestFolderWithOneItem();
            const string REGEXPATTERN = "t*tI?em";
            var searchRegex = new Regex(REGEXPATTERN);

            SearchResult searchResult = testFolder.Search(searchRegex);

            Assert.IsTrue(searchResult.ResultFound);
            Assert.IsTrue(searchResult.FoundItems.Single() == testItem);
            Assert.IsFalse(searchResult.FoundFolders.Any());
        }

        [TestMethod]
        public void Search_ChildItemMatchingRegex_FindsMatch()
        {
            (Folder testFolder, Item testItem) = CreateTestFolderWithOneItem();
            const string REGEXPATTERN = "testItem";
            var searchRegex = new Regex(REGEXPATTERN);

            SearchResult searchResult = testFolder.Search(searchRegex);

            Assert.IsTrue(searchResult.ResultFound);
            Assert.IsTrue(searchResult.FoundItems.Single() == testItem);
            Assert.IsFalse(searchResult.FoundFolders.Any());
        }

        [TestMethod]
        public void Search_SubFolderMatchingRegex_FindsMatch()
        {
            (Folder testFolder, _) = CreateTestFolderWithOneItem();
            var subFolder = new Folder(testFolder, "subfolder");
            testFolder.AddFolder(subFolder);
            var lowestSubFolder = new Folder(testFolder, "lowestSubfolder");
            subFolder.AddFolder(lowestSubFolder);

            const string REGEXPATTERN = "lowestSubfolder";
            var searchRegex = new Regex(REGEXPATTERN);

            SearchResult searchResult = testFolder.Search(searchRegex);

            Assert.IsTrue(searchResult.ResultFound);
            Assert.IsFalse(searchResult.FoundItems.Any());
            Assert.IsTrue(searchResult.FoundFolders.Single() == lowestSubFolder);
        }

        [TestMethod]
        public void Search_MismatchingRegex_FindsNoMatches()
        {
            (Folder testFolder, _) = CreateTestFolderWithOneItem();
            const string REGEXPATTERN = "noMatch";
            var searchRegex = new Regex(REGEXPATTERN);

            SearchResult searchResult = testFolder.Search(searchRegex);

            Assert.IsFalse(searchResult.ResultFound);
            Assert.IsFalse(searchResult.FoundItems.Any());
            Assert.IsFalse(searchResult.FoundFolders.Any());
        }

        private static Folder CreateEmptyTestFolder()
        {
            var category = new Category("test");
            RootFolder rootFolder = category.RootFolder;
            var testFolder = new Folder(rootFolder, "testFolder");
            rootFolder.AddFolder(testFolder);
            return testFolder;
        }

        private static (Folder Folder, Item Item) CreateTestFolderWithOneItem()
        {
            Folder testFolder = CreateEmptyTestFolder();
            var testItem = new Item(testFolder, "testItem");
            testFolder.AddItem(testItem);
            return (testFolder, testItem);
        }

        private static Folder SetupDestinationFolder() => new(null, "destinationFolder");
    }
}