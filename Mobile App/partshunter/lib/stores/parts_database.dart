import 'dart:convert';

import 'package:firebase_database/firebase_database.dart';
import 'package:flutter/material.dart';
import 'package:mobx/mobx.dart';

part 'parts_database.g.dart';

class PartsDatabaseStore = _PartsDatabaseStore with _$PartsDatabaseStore;

abstract class _PartsDatabaseStore with Store {
  ///PartsDatabaseStore _partsDatabaseStore = PartsDatabaseStore();
  ///

  final databaseReference = FirebaseDatabase.instance.reference();

  @observable
  Color primaryColor = Color.fromRGBO(41, 55, 109, 1.0);

  @observable
  Color secondaryColor = Color.fromRGBO(155, 252, 255, 1.0);

  @observable
  Color tertiaryColor = Color.fromRGBO(155, 252, 255, 1.0);

  @observable
  List<Map<dynamic, dynamic>> json = [];

  @observable
  List<DropdownMenuItem<String>> dropDownMenuItems;

  @observable
  List<Map<dynamic, dynamic>> lists = [];

  @action
  void buildAndGetDropDownMenuItems() {
    bool alreadyExist = false;
    List<DropdownMenuItem<String>> items = new List();

    items.clear();

    items.add(new DropdownMenuItem(value: json[0]["Category"], child: new Text(json[0]["Category"])));

    
for (int i = 0; i < json.length; i++) {
    
    for (int y = 0; y < items.length; y++) {      
    
        if (items[y].value == json[i]["Category"]){
          alreadyExist = true;
          break;
        }
    }
    
    if(alreadyExist == false)
      items.add(new DropdownMenuItem(value: json[i]["Category"], child: new Text(json[i]["Category"])));
    else
      alreadyExist = false;
}







    if (dropDownMenuItems != null) dropDownMenuItems.clear();

    dropDownMenuItems = items;


  }

  @action
  getF() async {
    await databaseReference.once().then((DataSnapshot _snap) {
      getParts(snap: _snap);
    });
  }

  @action
  Future<void> getParts({AsyncSnapshot<DataSnapshot> snapshot, DataSnapshot snap}) async {
    lists.clear();
    json.clear();

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

          String _string = '{' +
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

          json.add(jsonDecode(_string));

          lists.add(values);
        });
      }
    });
    buildAndGetDropDownMenuItems();
  }
}
