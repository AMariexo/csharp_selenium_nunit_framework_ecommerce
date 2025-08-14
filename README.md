
---

## Overview

This is an automation framwork for testing the SauceDemo e commerce site. The programming language used is C# using NUnit framework with Selenium as the UI automaton driver. A node server is executed in order to hit an API endpoint to access test data. Extent reports is consumed for reporting. These test scripts are kicked off when a branch is merged into master. 

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
  Validates post-login behavior, product title, cart count, item sort by price and description (asending and desending)

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

### ▶ Locally - run the server in order to access the test data via the test scripts

1. Open cmd prompt where the server is located
2. type in `node server.js`
3. keep server running in order for the test scripts to access the json test data

### ▶ From Visual Studio:

1. Open the `.sln` in Visual Studio
2. Set the test project as Startup
3. Build the solution
4. Run tests via **Test Explorer**

### ▶ From CLI:

```bash
dotnet test
