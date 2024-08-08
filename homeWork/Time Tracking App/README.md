Certainly! Here's the revised version without the mentions of "bonus" or "homework":

# **⏳ Time Tracking App**

Time is one of the most valuable resources we have. Whether we're learning, working, or spending time with friends, everything is done in increments of time. Organizing and tracking how we use our time can greatly enhance productivity. This app is designed to help users track the time they spend on various activities, save that data, and compile statistics for insightful analysis.

## Core Features 🎈

- **User Authentication**:
  - **Log in and Register**: Users can create an account or log in to an existing one.
  - **Log out**: Easily log out of the application when finished.
  - **Main Menu Navigation**: Return to the main menu from any screen.

- **Time Tracking**:
  - **Activity Tracking**: Users can start and stop tracking time for specific activities.
  - **Predefined Activities**: The app includes a set of predefined activities with specific options and values.

- **User Statistics**:
  - View detailed statistics on how time is spent across different activities.

- **Account Management**:
  - Options to update personal information, change the password, or even deactivate the account.

## Detailed Features 📌

### **User Authentication**

- **Registration Details**:
  - Collect the user's first name, last name, age, username, and password.

- **Validation Criteria**:
  - **Username**: Must be at least 5 characters long.
  - **Password**: Must be at least 6 characters long and contain at least one uppercase letter and one number.
  - **Name Validation**: First and last names should not contain numbers and must be at least 2 characters long.
  - **Age**: Must be between 18 and 120 years old.
  - **Login Attempts**: After three failed login attempts, the application should close with a goodbye message.

### **Main Menu Options**

- **Log Out**:
  - Available directly from the main menu, and redirects the user back to the login screen upon selection.

- **Activity Tracking**:
  - Access a list of predefined activities available for time tracking.
    - **Reading**:
      - Extra Info: Number of pages, type (e.g., Belles Lettres, Fiction, Professional Literature).
    - **Exercising**:
      - Extra Info: Type (e.g., General, Running, Sport).
    - **Working**:
      - Extra Info: Working location (Office or From Home).
    - **Other Hobbies**:
      - Extra Info: Name of the hobby.

  - **How Tracking Works**:
    - The user selects an activity, and the app starts a countdown timer for that activity.
    - The timer stops when the user hits "Enter," and the time spent is saved.
    - After stopping the timer, the user provides extra details relevant to the activity.
    - A summary message displays the time spent before redirecting the user back to the main menu.
    - Each user's activities are tracked separately.

### **User Statistics**

- Accessible from the main menu, this section provides various statistics based on the user's tracked activities:
  - **Reading**:
    - Total time spent (in hours).
    - Average time per activity (in minutes).
    - Total number of pages read.
    - Favorite type (the most frequently logged category).
  - **Exercising**:
    - Total time spent (in hours).
    - Average time per activity (in minutes).
    - Favorite type (the most frequently logged category).
  - **Working**:
    - Total time spent (in hours).
    - Average time per activity (in minutes).
    - Comparison between home and office work time (in hours).
  - **Hobbies**:
    - Total time spent (in hours).
    - A list of all recorded hobby names (excluding duplicates).
  - **Global**:
    - Total time spent on all activities (in hours).
    - Most frequently tracked activity.

### **Account Management**

- Also accessible from the main menu, this section allows users to:
  - Change their password.
  - Update their first and last names.
  - Deactivate their account.
    - Deactivated users will be prompted to reactivate their account upon login.

### **Menu Navigation and Validation**

- **Back Option**: Available in the Statistics, Account Management, and Activities menus, allowing users to return to the main menu.
- **Input Validation**: Ensure users only enter valid options.
  - Invalid inputs trigger red error messages.
  - Successful actions trigger green success messages.

### **Save Progress**

- The application saves user progress, ensuring that all data remains intact even when the app is closed and reopened.

---

This version gives users a clear understanding of the time tracking app's features and how to use it effectively without the extra references.
