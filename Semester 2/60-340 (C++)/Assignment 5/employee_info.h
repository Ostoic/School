#ifndef EMPLOYEE_INFO_H
#define EMPLOYEE_INFO_H

#include <string>
#include <iostream>

class employee_info
{
public:
	employee_info(unsigned int id, const std::string& name)
		: id_(id)
		, name_(name)
	{}

	const std::string& name() const
	{ return this->name_; }

	unsigned int id() const
	{ return this->id_; }

private:
	unsigned int id_;
	std::string name_;
};

inline bool operator==(const employee_info& lhs, const employee_info& rhs)
{ return lhs.id() == rhs.id() || lhs.name() == rhs.name(); }

inline bool operator<(const employee_info& lhs, const employee_info& rhs)
{ return lhs.id() < rhs.id(); }

inline bool operator>(const employee_info& lhs, const employee_info& rhs)
{ return lhs.id() > rhs.id(); }

inline std::ostream& operator<<(std::ostream& stream, const employee_info& info)
{
	if (info.id() != 0)
		stream << "ID Number: " << info.id() << '\t';

	if (!info.name().empty())
		stream << "Name: " << info.name();

	stream << "\n";
	return stream;
}

#endif