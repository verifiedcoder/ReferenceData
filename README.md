# ReferenceData
A study in how to handle the common problem of reference data.

Reference data is data that is often seeded to a database during initial creation. It is (for the most part) immutable data that should not change and is often used as, for example, a source of truth for dropdown (choice) lists.

The sample provided in this repository provides a means of making the source of truth for reference data as **source code** (C# Enums to be precise).

It allows the developer to utilise strongly typed access to reference data throughout an application, from the data through to the presentation layer.

Some static helper and extension methodss are provided to make this process seamless. Run the project to observe how that is achieved.
