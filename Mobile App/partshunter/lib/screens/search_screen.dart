//Flutter
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';

import 'package:firebase_database/firebase_database.dart';
import 'package:flutter_mobx/flutter_mobx.dart';

import 'package:partshunter/models/todo.dart';

//Application
import 'dart:convert';

import 'package:partshunter/stores/parts_database.dart';

//Screens

//Stores

class SearchScreen extends StatefulWidget {
  @override
  _SearchScreenState createState() => _SearchScreenState();
}

class _SearchScreenState extends State<SearchScreen> {
  PartsDatabaseStore _partsDatabaseStore = PartsDatabaseStore();

  final databaseReference = FirebaseDatabase.instance.reference();

  @override
  void initState() {
    _partsDatabaseStore.getF();
     //_partsDatabaseStore.getParts(snapshot: snapshot);
  }
  

  int scaffoldBottomIndex = 1;

  void scaffoldBottomOnTap(int index) {
    setState(() {
      scaffoldBottomIndex = index;
    });
  }

  

  createData(String category, String description, String drawer) async {
    Todo todo = new Todo(description, drawer);

    await databaseReference.reference().child(category).push().set(todo.toJson());
  }

  readData() async {
    await databaseReference.once().then((DataSnapshot _snapshot) {
      print('Data : ${_snapshot.value}');
    });
  }




  getCategory(String category) async {

    await databaseReference.child(category).once().then((DataSnapshot _snapshot) {
      _partsDatabaseStore.getParts(snap: _snapshot);
    });
  }

  void deleteData(String drawer) {
    databaseReference.child('flutterDevsTeam1').remove();
  }

  void updateData(String drawer, String description) {
    databaseReference.child('flutterDevsTeam1').update({'description': 'TESTE'});
  }

  String dropdownValue;

  int len = 0;
  int len2 = 0;
  Map<dynamic, dynamic> values;
  var value2;

  dynamic myList;

  List<Map<dynamic, dynamic>> lists = [];

  getClientes() async {
    await databaseReference.once().then((DataSnapshot snapshot) {
      value2 = snapshot;
      len = snapshot.value.length;
    });

    return values;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      bottomNavigationBar: BottomNavigationBar(
        type: BottomNavigationBarType.fixed,
        currentIndex: scaffoldBottomIndex,
        onTap: scaffoldBottomOnTap,
        unselectedItemColor: Colors.grey,
        selectedItemColor: Color.fromRGBO(65, 91, 165, 1.0),
        items: [
          BottomNavigationBarItem(
            icon: Icon(Icons.search),
            label: "Search",
          ),
          BottomNavigationBarItem(icon: Icon(Icons.library_add), label: "New"),
          BottomNavigationBarItem(icon: Icon(Icons.keyboard_hide_outlined), label: "Keypad"),
          BottomNavigationBarItem(icon: Icon(Icons.settings), label: "Config"),
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
                        value: dropdownValue,
                        onChanged: (String newValue) {
                          
                          setState(() {
                            dropdownValue = newValue;
                          });
                            
                          
                        },
                        items: _partsDatabaseStore.dropDownMenuItems, /*<String>['One', 'Two', 'Free', 'Four'].map<DropdownMenuItem<String>>((String value) {
                        return DropdownMenuItem<String>(
                          value: value,
                          child: Text(value),
                        );
                      }).toList(),

                      */
                      );
                    }),
                  ),
                ),
                Container(
                  child: TextButton(
                      onPressed: () {
                        getCategory(dropdownValue);
                        print(dropdownValue);
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
                      onPressed: () {},
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
          TextButton(
              onPressed: () {
                createData("RESISTOR", "100R", "99");
              },
              child: Text("CREATE")),
          TextButton(onPressed: readData, child: Text("READ")),
          //TextButton(onPressed: updateData, child: Text("UPDATE")),
          //TextButton(onPressed: deleteData, child: Text("DELETTE")),

  
          Container(
              decoration: BoxDecoration(
                border: Border.all(color: Colors.grey[300]),
              ),
              child: Observer(builder: (_) {
                return FutureBuilder(
                    future: databaseReference.once(),
                    builder: (context, AsyncSnapshot<DataSnapshot> snapshot) {
                      len = snapshot.data.value.length;

                      if (snapshot.hasData) {
                       // _partsDatabaseStore.getParts(snapshot: snapshot);

                        return new DataTable(
                          columns: const <DataColumn>[
                            DataColumn(
                              label: Text(
                                'CATEGORY',
                                style: TextStyle(fontStyle: FontStyle.italic),
                              ),
                            ),
                            DataColumn(
                              label: Text(
                                'DESCRIPTION',
                                style: TextStyle(fontStyle: FontStyle.italic),
                              ),
                            ),
                            DataColumn(
                              label: Text(
                                'DRAWER',
                                style: TextStyle(fontStyle: FontStyle.italic),
                              ),
                            ),
                          ],
                          rows: List<DataRow>.generate(
                              len,
                              (index) => DataRow(cells: [
                                    DataCell(Text(_partsDatabaseStore.json[index]["Category"])),
                                    DataCell(Text(_partsDatabaseStore.json[index]["Description"])),
                                    DataCell(Text(_partsDatabaseStore.json[index]["Drawer"])),
                                  ])),
                        );
                      } else
                        return CircularProgressIndicator();
                    });
              })),
        ],
      ),
    );
  }
}
