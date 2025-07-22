
---

## 🧪 Technologies Used

| Tool               | Purpose                          |
|--------------------|----------------------------------|
| **C#**             | Programming language             |
| **NUnit**          | Test framework                   |
| **Selenium WebDriver** | UI automation driver         |
| **ChromeDriver**   | Browser automation (Chrome)      |
| **Page Object Model** | Design pattern to decouple tests from UI locators |

---

## 🧪 Test Coverage

### ✅ Login Test Class

Contains 8 tests:

1. **LoginSuccessfully** – Valid login
2. **RequiredUsername** – Username missing
3. **RequiredPassword** – Password missing
4. **RequiredUsernameAndPassword** – Both fields missing
5. **InvalidUsername** – Invalid credentials
6. **InvalidPassword** – Invalid password
7. **SpecialCharactersUsername** – Input with special characters
8. **ClearError** – Close error banner

---

## 📄 Page Objects

- **`LoginPage.cs`**  
  Encapsulates all locators and actions for the login screen.

- **`ProductPage.cs`**  
  Validates post-login behavior and product title.

---

## 🔧 Base Driver Class

- `BaseDriver.cs` handles WebDriver initialization.
- Currently supports **ChromeDriver**.
- Easily extendable to include FirefoxDriver, Edge, etc.

---

## 🧰 Utils

- `ReturnTestData.cs` contains logic to fetch login credentials from a local API.
- JSON file (`loginData.json`) is served via a lightweight API and deserialized in the framework.

---

## 🧪 Running the Tests

### ▶ From Visual Studio:

1. Open the `.sln` in Visual Studio
2. Set the test project as Startup
3. Build the solution
4. Run tests via **Test Explorer**

### ▶ From CLI:

```bash
dotnet test
