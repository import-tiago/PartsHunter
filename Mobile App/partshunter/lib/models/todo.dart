import 'package:firebase_database/firebase_database.dart';

class Todo {
  String key;
  String drawer;
  String description;

  Todo(this.drawer, this.description);

  Todo.fromSnapshot(DataSnapshot snapshot)
      : key = snapshot.key,
        description = snapshot.value["description"],
        drawer = snapshot.value["drawer"];

  toJson() {
    return {
      "Description": description,
      "Drawer": drawer,
    };
  }
}
