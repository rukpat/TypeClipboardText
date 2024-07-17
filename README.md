# TypeClipboardText

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

TypeClipboardText is a Windows utility that allows you to easily send the contents of your clipboard as keystrokes to any active window. This is particularly useful for automating repetitive typing tasks or inserting text into applications that don't support direct pasting.

## Features

- **System Tray Integration:** The application runs discreetly in the system tray, accessible via a right-click context menu.
- **Active Window Selection:**  Dynamically lists all active windows in the context menu for easy selection.
- **UI Automation:** Uses UI Automation to reliably send keystrokes to windows, even those with elevated privileges.
- **Logging:** Provides a log of actions and errors for troubleshooting.
- **Special Character Handling:**  Escapes special characters in the clipboard text for accurate input.

## Installation

1. **Download:** Download the latest release from the [Releases](https://github.com/rukpat/TypeClipboardText/releases) page.
2. **Extract:** Extract the ZIP file to a desired location.
3. **Run:** Double-click the `TypeClipboardText.exe` file to start the application.

## Usage

1. **Copy Text:** Copy the text you want to send to your clipboard (e.g., using Ctrl+C).
2. **Right-Click Tray Icon:** Right-click the TypeClipboardText icon in the system tray (notification area).
3. **Select Window:** Choose the target window from the list in the context menu.
4. **Send Text:** The text from your clipboard will be automatically sent to the selected window as if you typed it manually.

**Advanced:**

- **Edit Clipboard Text:** You can directly edit the clipboard text in the context menu before sending it.
- **Double-Click Tray Icon:**  Automatically sends the clipboard text to the last active window (configurable in the code).

## Requirements

- Windows 10 or 11
- .NET 8.0 Runtime or higher
- UIAutomationClient NuGet package

## Building from Source

1. **Clone the Repository:**
   ```
   git clone [https://github.com/rukpat/TypeClipboardText/releases](https://github.com/rukpat/TypeClipboardText.git)
   ```  
2. **Open in Visual Studio:** Open the `TypeClipboardText.sln` file in Visual Studio.
3. **Build:** Build the solution `(Ctrl+Shift+B)`.

> [!TIP]
> Use your favourite GenAI to debug and fix the errors 😊.

## Disclaimer

> [!CAUTION]
> **WARNING: Use the code with caution.**
> - This tool is intended for legal use only. Use it responsibly and respect copyright laws.
> - The author is not responsible for any misuse or damage caused by this software.


## Contributing
- Contributions are welcome! Please feel free to submit bug reports, feature requests, or p= ull requests.

## License
- This project is licensed under the MIT License. See the LICENSE file for details.
   
## Acknowledgements
- This project utilizes the `TextCopy` library for clipboard operations.
- It also leverages the `UIAutomationClient` NuGet package for UI automation functionality.

