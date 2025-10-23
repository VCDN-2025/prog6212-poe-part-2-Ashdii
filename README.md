Description of Code Changes from Part 1 to Part 2

From Part 1 to Part 2, several significant improvements and additions were made to enhance the overall structure, functionality, and presentation of the project.

1. Model Additions
 *A new Lecturer Model was created to manage lecturer data and support functionalities specific to lecturer accounts within the system.
 *The Claim Model was updated to include a DocumentPath property, allowing for easier management of uploaded claim documents without causing file-handling issues.

2. Controller Additions and Modifications
 *A new Admin Controller was introduced to handle administrative tasks, including viewing, managing, and processing claim information.
 *A Lecturer Controller was created to manage lecturer-related actions and provide a clear separation between admin and lecturer functionalities.
 *A Profile Controller was added to handle profile-related operations such as displaying and updating user information.

3. View Updates
 *New Views folders for Admin and Lecturer were added under the Views directory to organize and separate the interfaces for different user roles.
 *The Home Index View and the Layout View were redesigned to improve navigation, visual appearance, and consistency across pages.
 *The Admin Index and Lecturer Index pages were implemented to display relevant data and operations for each user type.

4.Design and UI Improvements
 *The overall design of the layout was changed to enhance user experience and create a cleaner, more modern interface.
 *Styling and formatting updates were made to ensure the system maintains a consistent visual identity throughout.