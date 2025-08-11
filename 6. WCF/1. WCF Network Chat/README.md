# 🗨️ WCF Chat Application

A simple client-server chat example built with **WCF** and a **WPF** client application.

## 📌 Features
- Connect and disconnect users  
- Send and receive real-time messages  
- Display sender name and timestamp  
- System notifications for user join/leave events  
- Asynchronous message sending (non-blocking UI)  

## 🛠️ Technologies
- **C# / .NET Framework**  
- **WCF** (Windows Communication Foundation)  
- **WPF** (Windows Presentation Foundation)  
- Asynchronous programming (`async/await`, `Task.Run`)  
- WCF Duplex Service (callback pattern)  

## 📂 Project Structure
- **`WCFChat`** — service contract and implementation  
- **`ChatHost`** — server hosting the WCF service  
- **`ChatClient`** — WPF graphical client connecting to the service  
