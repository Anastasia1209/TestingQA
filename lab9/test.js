const assert = require("assert");
const webdriver = require("selenium-webdriver");

const driver = new webdriver.Builder().forBrowser("chrome").build();
const By = webdriver.By;
async function testRun() {
	try {
		await driver.get("https://relouis.by/");

		let searchButton = await driver.findElement(
			By.xpath('//*[@id="search-form"]/label/i')
		);
		await searchButton.click();

		let textBox = await driver.findElement(By.xpath('//*[@id="search"]'));
		await textBox.sendKeys("помада\n");

		await driver.sleep(1000);

		let result = await driver.getTitle();
		assert.strictEqual(
			"Вы искали помада - Relouis - декоративная косметика",
			result
		);
	} catch (error) {
		console.error("Произошла ошибка:", error.message);
	} finally {
		driver.quit();
		console.log("Test passed!");
	}
}
testRun();
