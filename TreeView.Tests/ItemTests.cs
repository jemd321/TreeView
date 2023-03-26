using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeView.Tests
{
#pragma warning disable SA1600 // Elements should be documented
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Delete_Self_Deletes()
        {
            Folder testFolder = CreateEmptyTestFolder();
            var testItem = new Item(testFolder, "testItem");

            testItem.Delete();

            Assert.IsFalse(testFolder.ChildItems.Any());
        }

        [TestMethod]
        public void Move_ToADestinationFolder_MovesItemCorrectly()
        {
            (_, Item testItem) = CreateTestFolderWithOneItem();
            var destinationFolder = new Folder(null, "destinationFolder");

            testItem.Move(destinationFolder);

            Assert.IsTrue(destinationFolder.ChildItems.Any());
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
    }
}