# PascalCaseChecker NuGet Package

The PascalCaseChecker is a useful tool for validating type names in the current assembly. It identifies and lists out valid and invalid type names in PascalCase to the console, helping you ensure consistency in your codebase.

## Installation

You can easily integrate the PascalCaseChecker into your project using NuGet Package Manager:

```bash
dotnet add package PascalCaseChecker --version 1.3.0
```

## Usage

Use  PascalCaseChecker.PascalCaseCheck.Check();
This lists out the type names which are following and not following the PascalCase Convention.
