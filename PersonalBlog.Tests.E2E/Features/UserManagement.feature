Feature: User Management

  As a website owner
  I want to allow visitors to create accounts and log in
  So that they can access personalized features and content

  Scenario: Register a new user account
    Given I am on the homepage
    When I click on the Sign Up link
    Then I should be taken to the registration page
    And I should see a form to enter my email and password
    When I fill out the form and click 'Submit'
    Then I should receive an email to confirm my account
    And I should be redirected to the login page

  Scenario: Log in to the website
    Given I have a registered account
    When I click on the Submit link
    Then I should be taken to the login page
    And I should see a form to enter my email and password
    When I fill out the form and click 'Submit'
    Then I should be logged in to the website
    And I should be redirected to my personalized dashboard