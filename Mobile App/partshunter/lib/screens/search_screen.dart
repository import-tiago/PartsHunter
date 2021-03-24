//Flutter
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';

import 'package:firebase_database/firebase_database.dart';
import 'package:flutter/services.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:partshunter/screens/keypad_screen.dart';
import 'package:partshunter/screens/register_screen.dart';

//Application
import 'dart:convert';
import 'package:rflutter_alert/rflutter_alert.dart';

import 'package:partshunter/stores/store.dart';
import 'package:floating_action_row/floating_action_row.dart';

//Screens

//Stores

import 'package:partshunter/models/custom_dialog.dart';

class SearchScreen extends StatefulWidget {
  @override
  _SearchScreenState createState() => _SearchScreenState();
}

class _SearchScreenState extends State<SearchScreen> {
  PartsDatabaseStore store = PartsDatabaseStore();

  final firebase = FirebaseDatabase.instance.reference();

  @override
  void initState() {
    SystemChannels.textInput.invokeMethod('TextInput.hide');
    store.Get_Firebase_and_Convert_to_JSON();
  }

  int Current_BottomNavigation_Index = 1;

  void Change_BottomNavigation_Index(int index) {
    setState(() => Current_BottomNavigation_Index = index);
    switch (index) {
      case 1:
      store.Set_Hardware_Device(-1);
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => RegisterScreen()));
        break;
      case 2:
      store.Set_Hardware_Device(-1);
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => KeypadScreen()));
        break;
    }
  }

  String Current_Selected_DropDown_Value;
  String Editing_DropDown_Value;
  bool row1Selected = false;

  int selectedIndex = -1;
  bool isSelected = false;

  bool checkbox_state = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      bottomNavigationBar: BottomNavigationBar(
        type: BottomNavigationBarType.fixed,
        currentIndex: 0,
        onTap: (int index) => Change_BottomNavigation_Index(index),
        unselectedItemColor: Colors.grey,
        selectedItemColor: Color.fromRGBO(65, 91, 165, 1.0),
        items: [
          BottomNavigationBarItem(
            icon: Icon(Icons.search),
            label: "Search",
          ),
          BottomNavigationBarItem(icon: Icon(Icons.library_add), label: "New"),
          BottomNavigationBarItem(icon: Icon(Icons.keyboard_hide_outlined), label: "Keypad"),
        ],
      ),
      /*    
      floatingActionButton: FloatingActionButton(
          backgroundColor: Colors.red,
          onPressed: () {},
          child: const Icon(
            Icons.edit,
            color: Colors.white,
          ),
        ),
*/
      floatingActionButton: Builder(
        builder: (_){
              return Visibility(
          visible: store.Show_Buttons_Edit_and_Delete,
          child: FloatingActionRow(
            color: Color.fromRGBO(41, 55, 109, 1.0),
            children: <Widget>[
              FloatingActionRowButton(
                  icon: Icon(
                    Icons.delete,
                    color: Colors.white,
                  ),
                  onTap: () {
                    Alert(
                      context: context,
                      type: AlertType.warning,
                      title: "DELETING",
                      desc: "Want to remove this part from the database?",
                      buttons: [
                        DialogButton(
                            child: Container(
                              height: 40,
                              width: 90,
                              child: Center(
                                child: Text(
                                  'YES',
                                  style: TextStyle(fontSize: 20, color: Colors.white),
                                ),
                              ),
                              decoration: new BoxDecoration(
                                borderRadius: new BorderRadius.all(new Radius.circular(5.0)),
                                color: Color.fromRGBO(41, 55, 109, 1.0),
                              ),
                            ),
                            onPressed: () {
                              store.deleteData(store.JSON_Obj[store.DataTable_Selected_Row]["Category"],
                                  store.JSON_Obj[store.DataTable_Selected_Row]["Description"], store.JSON_Obj[store.DataTable_Selected_Row]["Drawer"]);

                                     if (store.JSON_Obj.length <= 1) 
                                     store.Show_Buttons_Edit_and_Delete = false;
                                     setState(() {
                                       
                                     });
        

                              Navigator.of(context, rootNavigator: true).pop();
                            },
                            color: Colors.transparent),
                        DialogButton(
                          child: Text(
                            'CANCEL',
                            style: TextStyle(
                              fontSize: 20,
                              color: Color.fromRGBO(41, 55, 109, 1.0),
                            ),
                          ),
                          onPressed: () => Navigator.of(context, rootNavigator: true).pop(),
                          color: Colors.transparent,
                        )
                      ],
                    ).show();
                  }),
              FloatingActionRowDivider(),
              FloatingActionRowButton(
                  icon: Icon(
                    Icons.edit,
                    color: Colors.white,
                  ),
                  onTap: () {
                    //Editing_DropDown_Value = store.JSON_Obj[store.DataTable_Selected_Row]["Category"];
                    store.Editing_Dropdown_Item = store.JSON_Obj[store.DataTable_Selected_Row]["Category"];
                    buildEditingScreen(store.JSON_Obj[store.DataTable_Selected_Row]["Category"],
                        store.JSON_Obj[store.DataTable_Selected_Row]["Description"], store.JSON_Obj[store.DataTable_Selected_Row]["Drawer"]);
                  }),
            ],
          ),
        );},
      ),
      body: Stack(alignment: Alignment.bottomCenter, children: [
        SingleChildScrollView(
          scrollDirection: Axis.vertical,
          child: Column(
            children: [
              Container(
                margin: EdgeInsets.only(right: 10, left: 0, top: 10, bottom: 10),
                child: Row(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: <Widget>[
                    Expanded(
                      child: Container(
                        height: 40,
                        margin: EdgeInsets.only(right: 10, left: 10),
                        padding: const EdgeInsets.only(left: 10.0, right: 10.0),
                        decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(5.0),
                            border: Border.all(color: Colors.grey[600], style: BorderStyle.solid, width: 0.80)),
                        child: Observer(builder: (_) {
                          return DropdownButton<String>(
                            underline: SizedBox(),
                            hint: Text("Category"),
                            isExpanded: true,
                            value: Current_Selected_DropDown_Value,
                            onChanged: (String newValue) {
                              setState(() {
                                Current_Selected_DropDown_Value = newValue;
                              });

                              store.Fill_DataTrable_from_Selected_Category(Current_Selected_DropDown_Value);
                            },
                            items: store.dropDownMenuItems,
                          );
                        }),
                      ),
                    ),
                    Container(
                      child: TextButton(
                          onPressed: () {
                            store.List_All_Parts();
                          },
                          child: Text(
                            'List All',
                            style: TextStyle(fontSize: 16),
                          ),
                          style: ButtonStyle(
                              backgroundColor: MaterialStateProperty.all<Color>(Color.fromRGBO(41, 55, 109, 1.0)),
                              side: MaterialStateProperty.all(BorderSide(width: 2, color: Color.fromRGBO(41, 55, 109, 1.0))),
                              foregroundColor: MaterialStateProperty.all(Colors.white),
                              padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 5, horizontal: 20)),
                              textStyle: MaterialStateProperty.all(TextStyle(fontSize: 30)))),
                    ),
                  ],
                ),
              ),
              Container(
                margin: EdgeInsets.only(right: 10, left: 0),
                child: Row(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: <Widget>[
                    Expanded(
                      child: Container(
                          height: 40,
                          margin: EdgeInsets.only(right: 10, left: 10),
                          child: TextField(
                            keyboardType: TextInputType.visiblePassword,
                            onChanged: (input) => store.Description_Search_Input = input,
                            textAlign: TextAlign.left,
                            decoration: InputDecoration(
                              hintText: 'Description',
                              border: const OutlineInputBorder(),
                              contentPadding: EdgeInsets.only(left: 10, right: 10),
                            ),
                          )),
                    ),
                    Container(
                      child: TextButton(
                          onPressed: () {
                            store.Fill_DataTrable_from_Search(store.Description_Search_Input);
                          },
                          child: Text(
                            'Search',
                            style: TextStyle(fontSize: 16),
                          ),
                          style: ButtonStyle(
                              backgroundColor: MaterialStateProperty.all<Color>(Color.fromRGBO(41, 55, 109, 1.0)),
                              side: MaterialStateProperty.all(BorderSide(width: 2, color: Color.fromRGBO(41, 55, 109, 1.0))),
                              foregroundColor: MaterialStateProperty.all(Colors.white),
                              padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 5, horizontal: 20)),
                              textStyle: MaterialStateProperty.all(TextStyle(fontSize: 30)))),
                    ),
                  ],
                ),
              ),
              Observer(builder: (_) {
                return Container(
                  margin: EdgeInsets.only(top: 3, bottom: 10, right: 10, left: 18),
                  child: Align(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      store.DataTable_Length > 1 ? "${store.DataTable_Length} results found" : "${store.DataTable_Length} result found",
                      style: TextStyle(fontSize: 16, color: Colors.grey[600]),
                    ),
                  ),
                );
              }),
              SingleChildScrollView(
                scrollDirection: Axis.vertical,
                child: SingleChildScrollView(
                    scrollDirection: Axis.horizontal,
                    child: Container(
                        width: MediaQuery.of(context).size.width - 20,
                        margin: EdgeInsets.only(top: 10, right: 10, left: 10),
                        decoration: BoxDecoration(
                          border: Border.all(color: Colors.grey[300]),
                        ),
                        child: Observer(builder: (_) {
                          return DataTable(
                            showCheckboxColumn: store.DataTable_Selectable,
                            sortAscending: true,
                            sortColumnIndex: 2,
                            columns: const <DataColumn>[
                              DataColumn(
                                label: Text(
                                  'CATEGORY',
                                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                                ),
                              ),
                              DataColumn(
                                label: Text(
                                  'DESCRIPTION',
                                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                                ),
                              ),
                              DataColumn(
                                label: Text(
                                  'DRAWER',
                                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                                ),
                              ),
                            ],
                            rows: List<DataRow>.generate(store.DataTable_Length, (index) {
                              return DataRow.byIndex(
                                index: index,
                                color: MaterialStateColor.resolveWith((states) {
                                  if (index == selectedIndex) {
                                    return Colors.yellow[200];
                                  } else
                                    return Colors.transparent;
                                }),
                                selected: index == selectedIndex,
                                onSelectChanged: (val) {

                                  

                                  store.Set_Hardware_Device(int.parse(store.JSON_Obj[index]["Drawer"]));


                                  setState(() {
                                    if (index == selectedIndex && val == true) {
                                      selectedIndex = -1;
                                      store.DataTable_Selectable = false;
                                      store.Show_Buttons_Edit_and_Delete = false;
                                    }
                                    if (index == selectedIndex && val == false) {
                                      selectedIndex = -1;
                                      store.Set_Hardware_Device(-1);
                                      store.DataTable_Selectable = false;
                                      store.Show_Buttons_Edit_and_Delete = false;
                                    } else {
                                      selectedIndex = index;
                                      store.DataTable_Selected_Row = index;
                                      store.Show_Buttons_Edit_and_Delete = true;
                                      //store.DataTable_Selectable = true;
                                    }
                                  });
                                },
                                cells: [
                                  DataCell(Text(store.JSON_Obj[index]["Category"])),
                                  DataCell(Text(store.JSON_Obj[index]["Description"])),
                                  DataCell(Text(store.JSON_Obj[index]["Drawer"])),
                                ],
                              );
                            }),
                          );
                        }))),
              ),
            ],
          ),
        ),
      ]),
    );
  }

  bool showAlertDialog() {
    bool _return;
    Alert(
      context: context,
      type: AlertType.warning,
      title: "DELETING PART",
      desc: "Continue with the deletion?",
      buttons: [
        DialogButton(
            color: Colors.transparent,
            child: TextButton(
                onPressed: () {},
                child: Text(
                  'YES',
                  style: TextStyle(fontSize: 16),
                ),
                style: ButtonStyle(
                    backgroundColor: MaterialStateProperty.all<Color>(Color.fromRGBO(41, 55, 109, 1.0)),
                    side: MaterialStateProperty.all(BorderSide(width: 2, color: Color.fromRGBO(41, 55, 109, 1.0))),
                    foregroundColor: MaterialStateProperty.all(Colors.white),
                    padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 5, horizontal: 20)),
                    textStyle: MaterialStateProperty.all(TextStyle(fontSize: 30)))),
            onPressed: () {
              _return = true;
              Navigator.of(context, rootNavigator: true).pop();
            }),
        DialogButton(
            color: Colors.transparent,
            child: TextButton(
              onPressed: () {},
              child: Text(
                'CANCEL',
                style: TextStyle(fontSize: 16, color: Color.fromRGBO(41, 55, 109, 1.0)),
              ),
            ),
            onPressed: () {
              _return = false;
              Navigator.of(context, rootNavigator: true).pop();
            })
      ],
    ).show();
    return _return;
  }

  Widget buildDropDown(String category) {
    return StatefulBuilder(builder: (context, setState) {
      return Expanded(
        child: Container(
          height: 40,
          margin: EdgeInsets.only(left: 10),
          padding: const EdgeInsets.only(left: 10.0, right: 10.0),
          decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(5.0), border: Border.all(color: Colors.grey[600], style: BorderStyle.solid, width: 0.80)),
          child: Builder(builder: (_) {
            return DropdownButton<String>(
              underline: SizedBox(),
              hint: Text("Choose an existing category"),
              isExpanded: true,
              value: store.Editing_Dropdown_Item, //Editing_DropDown_Value,
              onChanged: (String newValue) {
                /*
              setState(() {
                Editing_DropDown_Value = newValue;
              });*/
                store.Editing_Dropdown_Item = newValue;
                store.Editing_Category = newValue;

                setState(() {});
                //store.Register_Category = newValue;
              },
              items: store.dropDownMenuItems,
            );
          }),
        ),
      );
    });
  }

  Widget buildTextField() {
    return Expanded(
      child: Container(
          height: 40,
          margin: EdgeInsets.only(right: 10, left: 10),
          child: TextField(
            onChanged: (input) {
              input = input.toUpperCase();
              store.Editing_Category = input;
            },
            textAlign: TextAlign.left,
            decoration: InputDecoration(
              hintText: 'Type a new category',
              border: const OutlineInputBorder(),
              contentPadding: EdgeInsets.only(left: 10, right: 10),
            ),
          )),
    );
  }

  Future<Widget> buildEditingScreen(String category, String description, String drawer) async {
    return showDialog(
        context: context,
        builder: (BuildContext context) {
          return StatefulBuilder(
            builder: (context, setState) {
              return AlertDialog(
                title: Center(child: Text('Editing Mode')),
                actions: <Widget>[
                  Center(
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        FlatButton(
                          onPressed: () {
                            //Navigator.pop(context, null);
                          },
                          child: TextButton(
                              onPressed: () {
                                Navigator.pop(context);
                              },
                              child: Text(
                                'CANCEL',
                                style: TextStyle(fontSize: 16),
                              ),
                              style: ButtonStyle(
                                  backgroundColor: MaterialStateProperty.all<Color>(Color.fromRGBO(41, 55, 109, 1.0)),
                                  side: MaterialStateProperty.all(BorderSide(width: 2, color: Color.fromRGBO(41, 55, 109, 1.0))),
                                  foregroundColor: MaterialStateProperty.all(Colors.white),
                                  padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 5, horizontal: 20)),
                                  textStyle: MaterialStateProperty.all(TextStyle(fontSize: 30)))),
                        ),
                        FlatButton(
                          onPressed: () {
                            //Navigator.pop(context, cityList);
                          },
                          child: TextButton(
                              onPressed: () async {
                                FocusScope.of(context).unfocus();

                                if (store.Editing_Category == "") store.Editing_Category = category;

                                if (store.Editing_Description == "") store.Editing_Description = description;

                                if (store.Editing_Drawer == "") store.Editing_Drawer = drawer;

                                store.editData(
                                    store.Editing_Category, store.Editing_Description, store.Editing_Drawer, category, description, drawer);

                                store.Editing_Category = "";
                                store.Editing_Description = "";
                                store.Editing_Drawer = "";
/*
                                if (Last_Register_Description != store.Register_Description && Last_Register_Drawer != store.Register_Drawer) {
                                  if (await store.createData(store.Register_Category, store.Register_Description, store.Register_Drawer) == true) {
                                    ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text("Success")));

                                    Last_Register_Category = store.Register_Category;
                                    Last_Register_Description = store.Register_Description;
                                    Last_Register_Drawer = store.Register_Drawer;
                                  } else
                                    ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text("Fail")));
                                } else
                                  ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text("Fail! Some Description and/or Drawer")));


                                  */

                                Navigator.pop(context);
                              },
                              child: Text(
                                'SAVE',
                                style: TextStyle(fontSize: 16),
                              ),
                              style: ButtonStyle(
                                  backgroundColor: MaterialStateProperty.all<Color>(Color.fromRGBO(41, 55, 109, 1.0)),
                                  side: MaterialStateProperty.all(BorderSide(width: 2, color: Color.fromRGBO(41, 55, 109, 1.0))),
                                  foregroundColor: MaterialStateProperty.all(Colors.white),
                                  padding: MaterialStateProperty.all(EdgeInsets.symmetric(vertical: 5, horizontal: 20)),
                                  textStyle: MaterialStateProperty.all(TextStyle(fontSize: 30)))),
                        ),
                      ],
                    ),
                  ),
                ],
                content: Container(
                  height: 160,
                  //width: double.minPositive,
                  child: Column(
                    children: [
                      Row(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: <Widget>[
                          checkbox_state ? buildTextField() : buildDropDown(category),
                          Wrap(
                            spacing: -8.0,
                            direction: Axis.horizontal,
                            alignment: WrapAlignment.center,
                            crossAxisAlignment: WrapCrossAlignment.center,
                            children: [
                              Checkbox(
                                  activeColor: Color.fromRGBO(41, 55, 109, 1.0),
                                  value: checkbox_state,
                                  onChanged: (value) {
                                    setState(() {
                                      checkbox_state = value;
                                    });
                                  }),
                              Text(
                                "new",
                                style: TextStyle(fontSize: 16, color: Colors.grey[600]),
                              ),
                            ],
                          )
                        ],
                      ),
                      Container(
                          height: 40,
                          margin: EdgeInsets.only(right: 10, left: 10, top: 10),
                          child: TextField(
                            keyboardType: TextInputType.visiblePassword,
                            controller: TextEditingController()..text = description,
                            onChanged: (input) => store.Editing_Description = input,
                            textAlign: TextAlign.left,
                            decoration: InputDecoration(
                              hintText: 'Description',
                              border: const OutlineInputBorder(),
                              contentPadding: EdgeInsets.only(left: 10, right: 10),
                            ),
                          )),
                      Container(
                          height: 40,
                          margin: EdgeInsets.only(right: 10, left: 10, top: 20),
                          child: TextField(
                             keyboardType: TextInputType.number,
                            controller: TextEditingController()..text = drawer,
                            onChanged: (input) => store.Editing_Drawer = input,
                            textAlign: TextAlign.left,
                            decoration: InputDecoration(
                              hintText: 'Drawer',
                              border: const OutlineInputBorder(),
                              contentPadding: EdgeInsets.only(left: 10, right: 10),
                            ),
                          )),
                    ],
                  ),
                ),
              );
            },
          );
        });
  }
}
