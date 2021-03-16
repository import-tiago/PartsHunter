import 'dart:convert';

import 'package:firebase_database/firebase_database.dart';
import 'package:flutter/material.dart';
import 'package:mobx/mobx.dart';

part 'parts_database.g.dart';

class PartsDatabaseStore = _PartsDatabaseStore with _$PartsDatabaseStore;

abstract class _PartsDatabaseStore with Store {
  ///PartsDatabaseStore _partsDatabaseStore = PartsDatabaseStore();
  ///

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
}
