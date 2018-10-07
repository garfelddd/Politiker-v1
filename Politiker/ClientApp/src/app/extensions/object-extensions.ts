interface ObjectConstructor {
  pascalCaseKeys(obj: Object): Object;
  defaultCaseKeys(obj: Object): Object;

}

Object.pascalCaseKeys = function (obj: Object) {
  return Object.keys(obj).reduce((p, c) => {
    let key = c.charAt(0).toUpperCase() + c.substr(1);
    p[key] = obj[c];
    return p;
  }, {});
}

Object.defaultCaseKeys = function (obj: Object) {
  return Object.keys(obj).reduce((p, c) => {
    let key = c.toLowerCase();
    p[key] = obj[c];
    return p;
  }, {});
}
