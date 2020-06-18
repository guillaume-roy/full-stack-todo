import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo(): Promise<unknown> {
    return browser.get(browser.baseUrl) as Promise<unknown>;
  }

  inputTodo(body: string) {
    return element(by.css('app-root > div.content > app-todo-input > input')).sendKeys(body);
  }

  addTodo() {
    return element(by.css('app-root > div.content > app-todo-input > button')).click();
  }

  getTodoText(nthChild: number) {
    return element(by.css(`app-root > div.content > app-todo-item:nth-child(${nthChild + 2}) > span`)).getText();
  }

  getTitleApp(): Promise<string> {
    return element(by.css('app-root > div.toolbar > span')).getText() as Promise<string>;
  }
}
