const assert = require("assert");
const calculate = require("./main.js");

//let firstNum = document.getElementById("numFirst").value;
//let secondNum = document.getElementById("numSec").value;

it("should add two numbers correctly", () => {
	assert.equal(calculate.plus(6, 2), 8);
});

it("should substract two numbers correctly", () => {
	assert.equal(calculate.minus(9, 4), 5);
});

it("should multiply two numbers correctly", () => {
	assert.equal(calculate.mul(8, 4), 32);
});

it("should divide two numbers correctly", () => {
	assert.equal(calculate.divide(54, 9), 6);
});

it("should handle division by zero", () => {
	assert.equal(calculate.divide(5, 0), "Infinity");
});

it("should failed when a string is used instead of a number", () => {
	assert.equal(calculate.validateNum("hej", 5), false);
});

it("should failed when a string is used instead of a number", () => {
	assert.equal(calculate.validateNum("hej", "hh"), false);
});

it("should failed when a string is used instead of a number", () => {
	assert.equal(calculate.validateNum(2, 3), true);
});

it("should failed when field is empty", () => {
	assert.equal(calculate.emptyField("", 6), false);
});

it("should failed when field is empty", () => {
	assert.equal(calculate.emptyField("", ""), false);
});

it("should failed when field is empty", () => {
	assert.equal(calculate.emptyField(6, 3), true);
});
