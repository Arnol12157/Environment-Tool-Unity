# Environment Tool

Environment Tool is a tool that allows you to create, edit, delete, and select configuration files for different environments such as development, staging, and production. Each environment can have different keys within its configuration through Scriptable Objects.

## Features

- **Configuration Creation**: Allows you to create specific configuration files for each environment.
- **Configuration Editing**: Facilitates editing existing configurations.
- **Configuration Deletion**: Option to delete configuration files that are no longer needed.
- **Environment Selection**: Easily switch between different environments (development, staging, production).
- **Use of Scriptable Objects**: Utilizes Scriptable Objects to manage configurations, enabling simple and scalable integration into Unity projects.

## Installation

1. Clone this repository to your local machine:
    ```bash
    git clone https://github.com/Arnol12157/TGUtils.EnvironmentTool.git
    ```
2. Open your project in Unity.
3. Copy the `Editor`, `EnvironmentManager` and `Resources` folders into the `Assets` folder of your Unity project.

## Usage

### Creating a Configuration

1. Navigate to the `TG Utils/Environment Tool` menu in the Unity toolbar.
2. Write the name of the new Environment(e.g., development, staging, production, ....) and press `Create`.
![image](https://github.com/Arnol12157/TGUtils.EnvironmentTool/assets/13397644/b65fc9b6-8fce-414d-b1e1-ac6b5b558beb)
3. Add the necessary keys and values for that environment's configuration.
![image](https://github.com/Arnol12157/TGUtils.EnvironmentTool/assets/13397644/441dc060-a3cb-4dff-b536-caa2dbd867b5)


### Editing a Configuration

1. Navigate to the `TG Utils/Environment Tool` menu in the Unity toolbar.
2. Choose the environment you wanna edit.
4. Modify the keys and values as needed.
![image](https://github.com/Arnol12157/TGUtils.EnvironmentTool/assets/13397644/441dc060-a3cb-4dff-b536-caa2dbd867b5)

### Deleting a Configuration

1. Navigate to the `TG Utils/Environment Tool` menu in the Unity toolbar.
2. Choose the environment you wanna delete and press `Delete`.
![image](https://github.com/Arnol12157/TGUtils.EnvironmentTool/assets/13397644/748c4ce2-27e6-4143-9579-1c358672a4aa)

### Selecting an Environment

1. Navigate to the `TG Utils/Environment Tool` menu in the Unity toolbar.
2. Pick the environment you want to activate (development, staging, production, ....) and press `Set Environment`.
3. The selected configuration will be loaded automatically and you can see the in the top of the window.
![image](https://github.com/Arnol12157/TGUtils.EnvironmentTool/assets/13397644/b2b9c805-10b0-4c8b-bf6a-921096564f2e)

## Use Example

Also was added a simple `EnvironmentManager.cs` as an example of use, there you can find a value to access directly to the data of the chosen Environment
![image](https://github.com/Arnol12157/TGUtils.EnvironmentTool/assets/13397644/61a34755-4365-4f8a-acfa-5c2538f5c619)
