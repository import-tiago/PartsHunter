import 'package:flutter/material.dart';
import 'package:mobx/mobx.dart';

part 'colors_store.g.dart';

class ColorsStore = _ColorsStore with _$ColorsStore;

abstract class _ColorsStore with Store {
  @observable
  Color primaryColor = Color.fromRGBO(41, 55, 109, 1.0);

  @observable
  Color secondaryColor = Color.fromRGBO(155, 252, 255, 1.0);

  @observable
  Color tertiaryColor = Color.fromRGBO(155, 252, 255, 1.0);
}
