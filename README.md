# A counter for filename occurrence for a given file
## Prerequisites
- Make sure you have the [.NET SDK](https://dotnet.microsoft.com/en-us/download) installed
-  ```fish
   dotnet --version
   
## Instructions
1. Clone this repository to your machine
2. Navigate to that directory
3. Execute with one path to a file
   ```fish
   dotnet run -- <file>
   ```
## Example
   ```fish
   dotnet run -- example.txt
   ```
## NOTE
Application must be run inside the folder for the cloned git repository

### Assumptions
- case-sensitivity (myfile.txt does not count mYfIlE.txt nor Myfile.txt in its contents)
- file encoding behaves normally and works with 
- content of the file is separated by newline

### Limitations
- The content (lines of potential filenames) must be separated by newlines, which requires formatting on the user's part if this is not the case for them. This was a deliberate sacrifice I made to maintain the readability, beauty and conciseness of the program. Fixing this would probably force me to adopt more imperative principles for the code responsible for counting the occurrences
- As for performance, my functional approach did not suffer much. Using while-loops and mutable states would make my code slightly faster but for such a small script I considered it not so worth-it. I also see to the fact that optmizing performance was not the main job here 
- My other approaches for counting have been left in a separate file 'AlternativeCounters.fs'
- Tests are limited in that they can only be executed by me because they rely on local file accessing


