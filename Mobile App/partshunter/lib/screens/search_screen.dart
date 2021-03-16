//Flutter
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';

import 'package:firebase_database/firebase_database.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:partshunter/screens/keypad_screen.dart';
import 'package:partshunter/screens/register_screen.dart';

//Application
import 'dart:convert';

import 'package:partshunter/stores/store.dart';

//Screens

//Stores

class SearchScreen extends StatefulWidget {
  @override
  _SearchScreenState createState() => _SearchScreenState();
}

class _SearchScreenState extends State<SearchScreen> {
  PartsDatabaseStore store = PartsDatabaseStore();

  final firebase = FirebaseDatabase.instance.reference();

  @override
  void initState() {
    store.Get_Firebase_and_Convert_to_JSON();
  }

  int Current_BottomNavigation_Index = 1;

  void Change_BottomNavigation_Index(int index) {
    setState(() => Current_BottomNavigation_Index = index);
    switch (index) {
     
      case 1:
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => RegisterScreen()));
        break;
      case 2:
        Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => KeypadScreen()));
        break;
    }
  }

  String Current_Selected_DropDown_Value;

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
      body: Column(
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
                        borderRadius: BorderRadius.circular(5.0), border: Border.all(color: Colors.grey[600], style: BorderStyle.solid, width: 0.80)),
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
                          return DataRow(cells: [
                            DataCell(Text(store.JSON_Obj[index]["Category"])),
                            DataCell(Text(store.JSON_Obj[index]["Description"])),
                            DataCell(Text(store.JSON_Obj[index]["Drawer"])),
                          ]);
                        }),
                      );
                    }))),
          ),
        ],
      ),
    );
  }
}
