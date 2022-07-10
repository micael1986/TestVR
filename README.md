# Exercise tests VR

## Overview

The main objective of this project is provided an example of a custom framework based in selenium + Specflow-xunit.

## Content

The repository has all necessary elements in order to run the test cases of the Feature folder.

## How to use

### Preconditions

- Install dotnet >= 6.0.x
- Install the last version Chrome and Firefox browser.
- If you want to check the tests in remote using selenium grid, you need to install docker and docker-compose.

### Commands

There are different environment variables that you can use to configure the browser and type of execution.

- **BROWSER**: The browser where the tests will be run, currently only _Chrome_ and _Firefox_ are supported. Default value : **chrome**.
- **MODE**: The type of execution, there are three modes:
  - **Local**: The browser will be executed in visual mode (**Default value**).
  - **Headless**: The browser will be executed in headless mode.
  - **Remote**: The test will be executed in visual mode in a selenium grid environment. It's necessary to configure the next environment variable in order to indicate the URL of the remote environment.
- **SELENIUM_REMOTE_URL**: The URL of the remote environment. Default value: **http://127.0.0.1:4444/wd/hub**.

> The features are running in parallel by default, so you only needs to run the tests in order to get a parallel execution.

### Use

Run the command `dotnet test` if you want to execute the test cases in chrome in visual mode. When you need to change the type o browser you need to change the environment variables, for example:

`dotnet test -e BROWSER=firefox -e MODE=remote -e SELENIUM_REMOTE_URL=http://selenium-grid.labtest.com/wd/hub`

## Improvements

- Configure the number of elements that are running in parallel by command line, currently the threads are configured in file `xunit.runner.json`
- Run in parallel the different browsers.
- Share the same browser instance instead of close and open the browser for each test.
