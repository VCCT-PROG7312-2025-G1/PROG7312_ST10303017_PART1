# PROG7312 Part 1 - ORACLE Application
**Student:** Calwyn Govender
**Student Number:** ST10303017

## 1. Project Overview

**ORACLE** is a web application created for the PROG7312 programming assignment. It's a prototype for a municipal service portal where citizens can report local issues like potholes or water leaks.

The main goals of this project were:
- To build a functional, non-console .NET application.
- To create a well-designed and user-friendly interface.
- **To exclusively use a custom-built data structure (`CustomLinkedList<T>`) for all data handling, as required by the assignment brief.**



## 3. Features Implemented

- **Modern UI:** The app features a custom background and a "swippable" carousel main menu using Bootstrap.
- **User Login:** Users can log in with pre-defined credentials to access the application.
- **Report an Issue:** A detailed form allows users to submit service requests with:
  - Location
  - Category 
  - Detailed Description
  - An option to attach a media file.
- **My Reports:** After logging in, users can see a list of the issues they have submitted.
- **Navigation:** Buttons are provided for easy navigation between the main menu and other pages.

## 4. Technical Details

- **Framework:** ASP.NET Core MVC
- **Language:** C#
- **Data Management:** All data (users, service requests) is stored in-memory using a **custom-built `CustomLinkedList<T>` class**. This was a core requirement of the assignment, and no built-in .NET collections like `List<T>` were used for data storage. The code for this is located in `/DataStructures/CustomLinkedList.cs`.
- **Styling:** Bootstrap 5 and a custom CSS file (`custom.css`) were used for the visual design.

## 5. How to Run This Project

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com/VCCT-PROG7312-2025-G1/PROG7312_ST10303017_PART1.git
    ```
2.  **Open in Visual Studio:** Open the `.sln` file in Visual Studio 2022.
3.  **Build:** Press `Ctrl+Shift+B` to build the project and restore dependencies.
4.  **Run:** Press `F5` to start the application. It will open in your web browser.

## 6. Sample Login Details

You can use these accounts to test the application:

- **Username:** `calwyn`
- **Password:** `calwyn123`

---
- **Username:** `lewis`
- **Password:** `lewis123`
  
---
- **Username:** `lebron`
- **Password:** `lebron123`
