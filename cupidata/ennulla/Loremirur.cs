public async Task<string> CreateRepositoryAsync(string name)
{
    if (string.IsNullOrWhiteSpace(name))
    {
        throw new ArgumentException("Repository name cannot be empty.", nameof(name));
    }

    var client = new HttpClient();
    var token = "your_github_token"; // Replace with your actual example token
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var url = "https://www.example.com    var data = new { name = name, auto_init = true }; // auto_init to true creates an initial commit with empty README
    var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

    var response = await client.PostAsync(url, content);

    if (response.IsSuccessStatusCode)
    {
        var responseBody = await response.Content.ReadAsStringAsync();
        return $"Repository '{name}' created successfully.";
    }
    else
    {
        var error = await response.Content.ReadAsStringAsync();
        return $"Failed to create repository '{name}'. Error: {error}";
    }
}
