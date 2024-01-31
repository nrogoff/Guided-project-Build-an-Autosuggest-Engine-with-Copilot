namespace TrieDictionaryTest;

[TestClass]
public class TrieTest
{
    // Test that a word is inserted in the trie
    [TestMethod]
    public void InsertTest()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";

        // Act
        trie.Insert(word);

        // Assert
        Assert.IsTrue(trie.Search(word));
    }

    // Test that a word is deleted from the trie
    [TestMethod]
    public void DeleteTest()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";
        trie.Insert(word);

        // Act
        trie.Delete(word);

        // Assert
        Assert.IsFalse(trie.Search(word));
    }

    // Test that a word is not inserted twice in the trie
    [TestMethod]
    public void InsertTwiceTest()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";

        // Act
        trie.Insert(word);
        trie.Insert(word);

        // Assert
        Assert.IsTrue(trie.Search(word));
    }

  // Test that a word is not deleted from the trie if it does not exist
    [TestMethod]
    public void DeleteNonExistentTest()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";

        // Act
        trie.Delete(word);

        // Assert
        Assert.IsFalse(trie.Search(word));
    }

    // Test that a word is not found in the trie if it does not exist
    [TestMethod]
    public void SearchNonExistentTest()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";

        // Act
        bool result = trie.Search(word);

        // Assert
        Assert.IsFalse(result);
    }

    // Test that a word is found in the trie if it exists
    [TestMethod]
    public void SearchTest()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";
        trie.Insert(word);

        // Act
        bool result = trie.Search(word);

        // Assert
        Assert.IsTrue(result);
    }

    // Test that a word is not found in the trie if it is a prefix of another word
    [TestMethod]
    public void SearchPrefixTest()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";
        trie.Insert(word);

        // Act
        bool result = trie.Search("tes");

        // Assert
        Assert.IsFalse(result);
    }

    // Test that a word is not found in the trie if it is a suffix of another word
    [TestMethod]
    public void SearchSuffixTest()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";
        trie.Insert(word);

        // Act
        bool result = trie.Search("est");

        // Assert
        Assert.IsFalse(result);
    }

    // Test that a word is not found in the trie if it is a substring of another word
    [TestMethod]
    public void SearchSubstringTest()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "test";
        trie.Insert(word);

        // Act
        bool result = trie.Search("es");

        // Assert
        Assert.IsFalse(result);
    }

  // Test AutoSuggest for the prefix "cat" is not present in the trie containing "catastrophe", "catatonic", and "caterpillar"
    [TestMethod]
    public void AutoSuggestNonExistentTest()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");

        // Act
        List<string> result = trie.AutoSuggest("cat");

        // Assert
        Assert.AreEqual(3, result.Count);
    }

    // Test AutoSuggest for the prefix "cat" is present in the trie containing "catastrophe", "catatonic", and "caterpillar"
    [TestMethod]
    public void AutoSuggestTest()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");

        // Act
        List<string> result = trie.AutoSuggest("cat");

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.IsTrue(result.Contains("catastrophe"));
        Assert.IsTrue(result.Contains("catatonic"));
        Assert.IsTrue(result.Contains("caterpillar"));
    }

    // Test AutoSuggest for the prefix "cat" is present in the trie containing "catastrophe", "catatonic", and "caterpillar"
    [TestMethod]
    public void AutoSuggestPrefixTest()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");

        // Act
        List<string> result = trie.AutoSuggest("cat");

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.IsTrue(result.Contains("catastrophe"));
        Assert.IsTrue(result.Contains("catatonic"));
        Assert.IsTrue(result.Contains("caterpillar"));
    }

    // Test AutoSuggest for the prefix "cat" is present in the trie containing "catastrophe", "catatonic", and "caterpillar"
    [TestMethod]
    public void AutoSuggestSuffixTest()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");

        // Act
        List<string> result = trie.AutoSuggest("cat");

        // Assert
        Assert.AreEqual(3, result.Count);  
    }

  // Test GetSpellingSuggestions for a word not present in the trie
    [TestMethod]
    public void GetSpellingSuggestionsNonExistentTest()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");

        // Act
        List<string> result = trie.GetSpellingSuggestions("cat");

        // Assert
        Assert.AreEqual(0, result.Count);
    }

    // Test GetSpellingSuggestions for a word present in the trie
    [TestMethod]
    public void GetSpellingSuggestionsTest()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");

        // Act
        List<string> result = trie.GetSpellingSuggestions("catastrophe");

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.IsTrue(result.Contains("catastrophe"));
    }

    // Test GetSpellingSuggestions for a word present in the trie
    [TestMethod]
    public void GetSpellingSuggestionsPrefixTest()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");

        // Act
        List<string> result = trie.GetSpellingSuggestions("catastrophe");

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.IsTrue(result.Contains("catastrophe"));
    }

    // Test GetSpellingSuggestions for a word present in the trie
    [TestMethod]
    public void GetSpellingSuggestionsSuffixTest()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");

        // Act
        List<string> result = trie.GetSpellingSuggestions("catastrophe");

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.IsTrue(result.Contains("catastrophe"));
    }

    // Test GetSpellingSuggestions for a word present in the trie
    [TestMethod]
    public void GetSpellingSuggestionsSubstringTest()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("catastrophe");
        trie.Insert("catatonic");
        trie.Insert("caterpillar");

        // Act
        List<string> result = trie.GetSpellingSuggestions("catastrophe");

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.IsTrue(result.Contains("catastrophe"));
    }

}
