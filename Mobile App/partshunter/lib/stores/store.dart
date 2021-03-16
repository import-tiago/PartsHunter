import 'dart:convert';

import 'package:firebase_database/firebase_database.dart';
import 'package:flutter/material.dart';
import 'package:mobx/mobx.dart';
import 'package:partshunter/models/todo.dart';

part 'store.g.dart';

class PartsDatabaseStore = _PartsDatabaseStore with _$PartsDatabaseStore;

abstract class _PartsDatabaseStore with Store {
  
  final firebase = FirebaseDatabase.instance.reference();

  @observable
  Color primaryColor = Color.fromRGBO(41, 55, 109, 1.0);

  @observable
  Color secondaryColor = Color.fromRGBO(155, 252, 255, 1.0);

  @observable
  Color tertiaryColor = Color.fromRGBO(155, 252, 255, 1.0);

  @observable
  List<Map<dynamic, dynamic>> JSON_Obj = [];

  @observable
  List<DropdownMenuItem<String>> dropDownMenuItems;

  @observable
  List<Map<dynamic, dynamic>> lists = [];

  @observable
  int DataTable_Length = 0;

  @observable
  String Description_Search_Input =  "";

  @observable
  int Keypad_Input;

  @computed
  String get SetHardwareDevice => Set_Hardware_Device(Keypad_Input);


  @action
  void Build_DropDown() {
    bool alreadyExist = false;
    List<DropdownMenuItem<String>> items = new List();

    items.clear();

    items.add(new DropdownMenuItem(value: JSON_Obj[0]["Category"], child: new Text(JSON_Obj[0]["Category"])));

    for (int i = 0; i < JSON_Obj.length; i++) {
      for (int y = 0; y < items.length; y++) {
        if (items[y].value == JSON_Obj[i]["Category"]) {
          alreadyExist = true;
          break;
        }
      }

      if (alreadyExist == false)
        items.add(new DropdownMenuItem(value: JSON_Obj[i]["Category"], child: new Text(JSON_Obj[i]["Category"])));
      else
        alreadyExist = false;
    }

    if (dropDownMenuItems != null) dropDownMenuItems.clear();

    dropDownMenuItems = items;
  }

  @action
  Get_Firebase_and_Convert_to_JSON() async {
    await firebase.once().then((DataSnapshot _snap) async {
      await Snapshot_to_JSON(snap: _snap);
    });
  }

  @action
  Future<void> Snapshot_to_JSON({AsyncSnapshot<DataSnapshot> snapshot, DataSnapshot snap}) async {
    lists.clear();
    JSON_Obj.clear();

    Map<dynamic, dynamic> values;

    if (snapshot != null)
      values = snapshot.data.value;
    else
      values = snap.value;

    await values.forEach((key1, values) {
      if (key1 != "HardwareDevice") {
        Map<dynamic, dynamic> values2 = values;
        values2.forEach((key, values) {
          String a = key1;
          String b = values["Description"];
          String c = values["Drawer"];

          String JSON_Str = '{' +
              '\"Category\"' +
              ':' +
              '\"' +
              a +
              '\"' +
              ',' +
              '\"Description\"' +
              ':' +
              '\"' +
              b +
              '\"' +
              ',' +
              '\"Drawer\"' +
              ':' +
              '\"' +
              c +
              '\"' +
              '}';

          JSON_Obj.add(jsonDecode(JSON_Str));

          lists.add(values);
        });
      }
    });

    DataTable_Length = JSON_Obj.length;
    Build_DropDown();
  }


bool equalsIgnoreCase(String string1, String string2) {
  return string1?.toLowerCase() == string2?.toLowerCase();
}

  @action
  Fill_DataTrable_from_Search(String input) async {
    
    await Get_Firebase_and_Convert_to_JSON();

    List<Map<dynamic, dynamic>> JSON_Obj_only_Description = [];
    
    for (int i = 0; i < JSON_Obj.length; i++) {

       var words = input.split(' ').toList();

       Set<String> wordsInput = Set.from(words);
       
       wordsInput.forEach((w) {

         String s = JSON_Obj[i]["Description"];




      var words2 = s.split(' ').toList();

       Set<String> wordsFirebase = Set.from(words2);
       
       wordsFirebase.forEach((_w) {

       if(equalsIgnoreCase( _w,  w) ){

          JSON_Obj_only_Description.add(JSON_Obj[i]);

        }

       });


         
/*
         if (s.contains(w)) {
           JSON_Obj_only_Description.add(JSON_Obj[i]);
         }
*/
       });      
    }

    JSON_Obj.clear();
    JSON_Obj = JSON_Obj_only_Description;
    DataTable_Length = JSON_Obj.length;

  }

  @action
  Fill_DataTrable_from_Selected_Category(String selected_category) async {
    await Get_Firebase_and_Convert_to_JSON();

    List<Map<dynamic, dynamic>> JSON_Obj_only_selected_category = [];

    for (int i = 0; i < JSON_Obj.length; i++) {
      if (JSON_Obj[i]["Category"] == selected_category) {
        JSON_Obj_only_selected_category.add(JSON_Obj[i]);
      }
    }

    JSON_Obj.clear();
    JSON_Obj = JSON_Obj_only_selected_category;
    DataTable_Length = JSON_Obj.length;
  }

  //createData("RESISTOR", "100R", "99");
  createData(String category, String description, String drawer) async {
    Todo todo = new Todo(description, drawer);

    await firebase.reference().child(category).push().set(todo.toJson());
  }

  readData() async {
    await firebase.once().then((DataSnapshot _snapshot) {
      print('Data : ${_snapshot.value}');
    });
  }

  void deleteData(String drawer) {
    firebase.child('flutterDevsTeam1').remove();
  }

  void updateData(String drawer, String description) {
    firebase.child('flutterDevsTeam1').update({'description': 'TESTE'});
  }

  List_All_Parts() async {
    await Get_Firebase_and_Convert_to_JSON();
  }

  Set_Hardware_Device(int input) async {

    if(input == null || input < -1 || input >599)
      input = -1;
    String output =  "${input},0,255,0,10,100";  

    await firebase.update({'HardwareDevice': output});


    
  }
  
}
