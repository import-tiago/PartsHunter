//Flutter
import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';

import 'package:firebase_database/firebase_database.dart';
import 'package:partshunter/models/todo.dart';

//Application

//Screens

//Stores

class SearchScreen extends StatefulWidget {
  @override
  _SearchScreenState createState() => _SearchScreenState();
}

class _SearchScreenState extends State<SearchScreen> {
  final databaseReference = FirebaseDatabase.instance.reference();

  int scaffoldBottomIndex = 1;

  void scaffoldBottomOnTap(int index) {
    setState(() {
      scaffoldBottomIndex = index;
    });
  }

  String dropdownValue;

  createData(
    String category,
    String description,
    String drawer,
  ) async {
    Todo todo = new Todo(description, drawer);
    await databaseReference
        .reference()
        .child(category)
        .push()
        .set(todo.toJson());

    //databaseReference.child(category).set(todo.toJson());
  }

  readData() async {
    await databaseReference.once().then((DataSnapshot _snapshot) {
      print('Data : ${_snapshot.value}');
    });
  }

  void deleteData(String drawer) {
    databaseReference.child('flutterDevsTeam1').remove();
  }

  void updateData(String drawer, String description) {
    databaseReference
        .child('flutterDevsTeam1')
        .update({'description': 'TESTE'});
  }

  int len = 0;
  Map<dynamic, dynamic> values;
  var value2;

  List<String> myList;

  List<Map<dynamic, dynamic>> lists = [];

  getClientes() async {
    await databaseReference.once().then((DataSnapshot snapshot) {
      //values = snapshot.value;
      value2 = snapshot;
      Map<dynamic, dynamic> map;
      final value = snapshot.value as Map;
      for (final key in value.keys) {
        map = value[key];
      }

      var x = snapshot.value.entries.elementAt(0).key;

/*
      //var a = values[0].value[0].value["Description"];
      for (var value in snapshot.value) {
        myList.add(value);
      }
      */

      len = snapshot.value.length;
    });

    //values = _qn;
    //len = _qn.value.length;

    //String s = values.data[index]["Description"];

    //values = _snapshot;
    //print('Data : ${_snapshot.value}');

    //var firestore = Firestore.instance;

    //QuerySnapshot values = await firestore.collection("clientes").getDocuments();

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
          BottomNavigationBarItem(
              icon: Icon(Icons.keyboard_hide_outlined), label: "Keypad"),
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
                        borderRadius: BorderRadius.circular(5.0),
                        border: Border.all(
                            color: Colors.grey[600],
                            style: BorderStyle.solid,
                            width: 0.80)),
                    child: DropdownButton<String>(
                      underline: SizedBox(),
                      hint: Text("Category"),
                      isExpanded: true,
                      value: dropdownValue,
                      onChanged: (String newValue) {
                        setState(() {
                          dropdownValue = newValue;
                        });
                      },
                      items: <String>['One', 'Two', 'Free', 'Four']
                          .map<DropdownMenuItem<String>>((String value) {
                        return DropdownMenuItem<String>(
                          value: value,
                          child: Text(value),
                        );
                      }).toList(),
                    ),
                  ),
                ),
                Container(
                  child: TextButton(
                      onPressed: () {},
                      child: Text(
                        'List All',
                        style: TextStyle(fontSize: 16),
                      ),
                      style: ButtonStyle(
                          backgroundColor: MaterialStateProperty.all<Color>(
                              Color.fromRGBO(41, 55, 109, 1.0)),
                          side: MaterialStateProperty.all(BorderSide(
                              width: 2,
                              color: Color.fromRGBO(41, 55, 109, 1.0))),
                          foregroundColor:
                              MaterialStateProperty.all(Colors.white),
                          padding: MaterialStateProperty.all(
                              EdgeInsets.symmetric(
                                  vertical: 5, horizontal: 20)),
                          textStyle: MaterialStateProperty.all(
                              TextStyle(fontSize: 30)))),
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
                          backgroundColor: MaterialStateProperty.all<Color>(
                              Color.fromRGBO(41, 55, 109, 1.0)),
                          side: MaterialStateProperty.all(BorderSide(
                              width: 2,
                              color: Color.fromRGBO(41, 55, 109, 1.0))),
                          foregroundColor:
                              MaterialStateProperty.all(Colors.white),
                          padding: MaterialStateProperty.all(
                              EdgeInsets.symmetric(
                                  vertical: 5, horizontal: 20)),
                          textStyle: MaterialStateProperty.all(
                              TextStyle(fontSize: 30)))),
                ),
              ],
            ),
          ),
          TextButton(
              onPressed: () {
                createData("RESISTOR", "10k", "3");
              },
              child: Text("CREATE")),
          TextButton(onPressed: readData, child: Text("READ")),
          //TextButton(onPressed: updateData, child: Text("UPDATE")),
          //TextButton(onPressed: deleteData, child: Text("DELETTE")),
          FutureBuilder(
              future: databaseReference.once(),
              builder: (context, AsyncSnapshot<DataSnapshot> snapshot) {
                if (snapshot.hasData) {
                  lists.clear();
                  Map<dynamic, dynamic> values = snapshot.data.value;

                  values.forEach((key, values) {
                    if (key != "HardwareDevice") {
                      Map<dynamic, dynamic> values2 = values;
                      values2.forEach((key, values) {
                        lists.add(values);
                      });
                    }
                    //if (values == "Description" || values == "Drawer")
                    // lists.add(values);
                  });
                  return new ListView.builder(
                      shrinkWrap: true,
                      itemCount: lists.length,
                      itemBuilder: (BuildContext context, int index) {
                        return Card(
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: <Widget>[
                              Text("Descripttion: " +
                                  lists[index]
                                      ["Description"]), //["Description"]),
                              Text("Drawer: " + lists[index]["Drawer"]),
                              //Text("Drawer: " + lists[index]['key']["Drawer"]),
                            ],
                          ),
                        );
                      });
                }
                return CircularProgressIndicator();
              })
        ],
      ),
    );
  }
}

class Data {}
