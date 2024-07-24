
# ASP.NET Data Passing Techniques

This repository demonstrates various techniques for passing data between controllers and views in ASP.NET. Each technique has its own use cases, benefits, and drawbacks.

## Table of Contents

1. [ViewData](#viewdata)
2. [ViewBag](#viewbag)
3. [TempData](#tempdata)
4. [Cookies](#cookies)
5. [Sessions](#sessions)
6. [State Server](#state-server)
7. [SQL Server](#sql-server)
8. [Application](#application)
9. [Anonymous Types](#anonymous-types)
10. [Contributing](#contributing)
11. [License](#license)

---

## ViewData

`ViewData` is a dictionary used to pass data from a controller to a view.

### Example

```csharp
// Controller
ViewData["name"] = "shoes";
ViewData["price"] = 3500;

// View
@{
    string name = ViewData["name"].ToString();
    int price = Convert.ToInt32(ViewData["price"]);
}
```

### Drawbacks

- Only available for the current request.
- Requires type casting.
- No compile-time error checking.

---

## ViewBag

`ViewBag` is a dynamic property that allows you to pass data without type casting.

### Example

```csharp
// Controller
ViewBag.Name = "Sachin";
ViewBag.Id = 23;

// View
@{
    string name = ViewBag.Name;
    int id = ViewBag.Id;
}
```

### Drawbacks

- Only available for the current request.
- No compile-time error checking.

---

## TempData

`TempData` is used to pass data between different requests.

### Example

```csharp
// Controller
TempData["message"] = "Data saved successfully.";

// Another Controller or Action
string message = TempData["message"]?.ToString();
```

### Drawbacks

- Data is deleted once accessed.
- Not suitable for large amounts of data.

---

## Cookies

`Cookies` are used to store data on the client side.

### Example

```csharp
// Creating a Cookie
HttpCookie cookie = new HttpCookie("user");
cookie.Value = "Sachin";
cookie.Expires = DateTime.Now.AddDays(1);
Response.Cookies.Add(cookie);

// Reading a Cookie
HttpCookie userCookie = Request.Cookies["user"];
string userName = userCookie?.Value;
```

### Drawbacks

- Can be manipulated by users.
- Limited storage capacity.

---

## Sessions

`Sessions` store data server-side and are unique to each user.

### Example

```csharp
// Setting a Session
Session["user"] = "Sachin";

// Getting a Session
string userName = Session["user"].ToString();
```

### Drawbacks

- Can be lost if the server is restarted.
- Requires additional server resources.

---

## State Server

`State Server` stores session data out-of-process to improve scalability.

### Configuration

```xml
<configuration>
  <system.web>
    <sessionState mode="StateServer" 
                  stateConnectionString="tcpip=127.0.0.1:42424" 
                  cookieless="false" 
                  timeout="20" />
  </system.web>
</configuration>
```

### Drawbacks

- Additional configuration required.
- Network latency can impact performance.

---

## SQL Server

`SQL Server` stores session data in a database for persistence across server restarts.

### Configuration

```xml
<configuration>
  <system.web>
    <sessionState mode="SQLServer" 
                  sqlConnectionString="Data Source=127.0.0.1;Initial Catalog=SessionStateDB;Integrated Security=True" 
                  cookieless="false" 
                  timeout="20" />
  </system.web>
</configuration>
```

### Drawbacks

- Requires a SQL Server instance.
- Can introduce database load.

---

## Application

`Application` is used to store data globally across all sessions and users.

### Example

```csharp
// Setting Application Data
System.Web.HttpContext.Current.Application["siteName"] = "MyWebsite";

// Getting Application Data
string siteName = System.Web.HttpContext.Current.Application["siteName"].ToString();
```

### Drawbacks

- Data is shared across all users.
- Requires careful management to avoid conflicts.

---

## Anonymous Types

Anonymous types are used to create objects without explicitly defining a class.

### Example

```csharp
var user = new { Name = "Sachin", Age = 30 };

// Accessing Anonymous Type
string name = user.Name;
int age = user.Age;
```

---

