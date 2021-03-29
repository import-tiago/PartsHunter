import 'package:flutter/material.dart';

class Part {
  String Category;
  String Description;
  String Drawer;

  Part(this.Category, this.Description, this.Drawer);

  @override
  String toString() {
    return '{${this.Category}, ${this.Description}, ${this.Drawer}}';
  }

  String Get(String object){
    switch(object){
      case "Category": return Category; break;
      case "Description": return Description; break;
      case "Drawer": return Drawer; break;
    }
  }
}