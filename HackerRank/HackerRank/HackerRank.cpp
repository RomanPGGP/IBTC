// HackerRank.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <bits/stdc++.h>

using namespace std;

class SinglyLinkedListNode {
public:
	int data;
	SinglyLinkedListNode *next;

	SinglyLinkedListNode(int node_data) {
		this->data = node_data;
		this->next = nullptr;
	}
};

class SinglyLinkedList {
public:
	SinglyLinkedListNode *head;
	SinglyLinkedListNode *tail;

	SinglyLinkedList() {
		this->head = nullptr;
		this->tail = nullptr;
	}

	void insert_node(int node_data) {
		SinglyLinkedListNode* node = new SinglyLinkedListNode(node_data);

		if (!this->head) {
			this->head = node;
		}
		else {
			this->tail->next = node;
		}

		this->tail = node;
	}
};

void print_singly_linked_list(SinglyLinkedListNode* node, string sep, ofstream& fout) {
	while (node) {
		fout << node->data;

		node = node->next;

		if (node) {
			fout << sep;
		}
	}
}

void free_singly_linked_list(SinglyLinkedListNode* node) {
	while (node) {
		SinglyLinkedListNode* temp = node;
		node = node->next;

		free(temp);
	}
}

// Complete the mergeLists function below.

/*
 * For your reference:
 *
 * SinglyLinkedListNode {
 *     int data;
 *     SinglyLinkedListNode* next;
 * };
 *
 */
SinglyLinkedListNode* mergeLists(SinglyLinkedListNode* head1, SinglyLinkedListNode* head2) {

	SinglyLinkedListNode* auxPtrh1;
	SinglyLinkedListNode* auxPtrh2;

	auxPtrh1 = head1;
	auxPtrh2 = head2;

	while (auxPtrh1 != NULL) {
		while (auxPtrh2 != NULL) {
			if (auxPtrh2->data < auxPtrh1->data) {
				auxPtrh1 = auxPtrh1->next;
				continue;
			}
			else {
				head2 = auxPtrh2->next;
				auxPtrh2->next = auxPtrh1->next;
				auxPtrh1->next = auxPtrh2;
				auxPtrh2 = head2;
			}
		}
	}

	return head1;
}

int main()
{
	ofstream fout(getenv("OUTPUT_PATH"));

	int tests;
	cin >> tests;
	cin.ignore(numeric_limits<streamsize>::max(), '\n');

	for (int tests_itr = 0; tests_itr < tests; tests_itr++) {
		SinglyLinkedList* llist1 = new SinglyLinkedList();

		int llist1_count;
		cin >> llist1_count;
		cin.ignore(numeric_limits<streamsize>::max(), '\n');

		for (int i = 0; i < llist1_count; i++) {
			int llist1_item;
			cin >> llist1_item;
			cin.ignore(numeric_limits<streamsize>::max(), '\n');

			llist1->insert_node(llist1_item);
		}

		SinglyLinkedList* llist2 = new SinglyLinkedList();

		int llist2_count;
		cin >> llist2_count;
		cin.ignore(numeric_limits<streamsize>::max(), '\n');

		for (int i = 0; i < llist2_count; i++) {
			int llist2_item;
			cin >> llist2_item;
			cin.ignore(numeric_limits<streamsize>::max(), '\n');

			llist2->insert_node(llist2_item);
		}

		SinglyLinkedListNode* llist3 = mergeLists(llist1->head, llist2->head);

		print_singly_linked_list(llist3, " ", fout);
		fout << "\n";

		free_singly_linked_list(llist3);
	}

	fout.close();

	return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
